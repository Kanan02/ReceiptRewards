using System.Globalization;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ReceiptRewards.Application.Services.Abstract;
using ReceiptRewards.Domain.Entities;
using ReceiptRewards.Domain.Enums;
using ReceiptRewards.Domain.Messaging.Events;
using ReceiptRewards.Domain.Repositories;
using ReceiptRewards.Domain.Requests;
using ReceiptRewards.Domain.Responses;

namespace ReceiptRewards.Application.Services.Concrete;

public class ReceiptService : IReceiptService
{
    private readonly IReceiptRepository _receiptRepository;
    private readonly ILogRepository _logRepository;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IEventBus _eventBus;

    public ReceiptService(
        IHttpContextAccessor contextAccessor,
        IReceiptRepository receiptRepository,
        IEventBus eventBus, ILogRepository logRepository)
    {
        _contextAccessor = contextAccessor;
        _receiptRepository = receiptRepository;
        _eventBus = eventBus;
        _logRepository = logRepository;
    }

    #region Admin

    public async Task<ApiValueResponse<List<Receipt>>> GetReceiptsWithFilter(
        ReceiptFilterRequest request
    )
    {
        IQueryable<Receipt> query = await _receiptRepository.GetAllAsync("User");

        if (!string.IsNullOrWhiteSpace(request.Msisdn))
            query = query.Where(x => x.User!.Msisdn == request.Msisdn);
        if (request.StartDate != null)
            query = query.Where(x => x.CreatedAt >= request.StartDate);
        if (request.EndDate != null)
            query = query.Where(x => x.CreatedAt < request.EndDate);
        if (request.Status != null)
            query = query.Where(x => x.Status == request.Status);
        if (request.Points != null)
            query = query.Where(x => x.Points == request.Points);

        var list = await query.OrderByDescending(x => x.CreatedAt).ToListAsync();
        return new ApiValueResponse<List<Receipt>>(list);
    }

    public async Task<ApiValueResponse<List<Receipt>>> GetReceiptsForApprovalAsync()
    {
        var list = await _receiptRepository.GetAllAsync(
            x => x.Status == ReceiptStatus.Pending,
            "User"
        );
        return new ApiValueResponse<List<Receipt>>(list.ToList());
    }

    #endregion

    public async Task<ApiValueResponse<List<Receipt>>> GetReceiptsAsync()
    {
        var userId = int.Parse(GetClaims().FirstOrDefault(x => x.Type == "userId")!.Value);

        var list = await _receiptRepository.GetAllAsync(x => x.UserId == userId);
        return new ApiValueResponse<List<Receipt>>(list.ToList());
    }

    public async Task<ApiResponse> AddAsync(ReceiptAddRequest request)
    {
        var allReceipts = (await _receiptRepository.GetAllAsync(c => c.FiscalId != null)).ToList();

        var existing = allReceipts
            .Where(c => c.FiscalId.Trim().Equals(request.FiscalId.Trim(), StringComparison.Ordinal))
            .FirstOrDefault();
        // var existing = await _receiptRepository.isExist(c => c.FiscalId.Trim() == request.FiscalId.Trim());
        if (existing == null)
        {
            Receipt receipt = new()
            {
                FiscalId = request.FiscalId,
                UserId = int.Parse(GetClaims().FirstOrDefault(x => x.Type == "userId")!.Value)
            };
            await _receiptRepository.AddAsync(receipt);
            await _receiptRepository.SaveAsync();
            await _eventBus.PublishAsync(
                new ReceiptMessagingEvent
                {
                    Receipt = receipt
                });
            return new ApiValueResponse<ReceiptResponse>(new ReceiptResponse(receipt));
        }

        if (existing.UserId == int.Parse(GetClaims().FirstOrDefault(x => x.Type == "userId")!.Value))
        {
            await _logRepository.AddAsync(new ErrorLog(LogType.FiscalAlreadyScanned.ToString()));
        }
        else
        {
            await _logRepository.AddAsync(new ErrorLog(LogType.FiscalScannedByAnotherUser.ToString()));
        }

        await _logRepository.SaveAsync();
        return new ApiResponse(new ApiError
            { ErrorCode = "409", ErrorMsg = "Receipt already exists" });
    }

    public async Task<ApiResponse> UpdateAsync(UpdateReceiptRequest request)
    {
        var receipt = await _receiptRepository
            .GetAsync(x => x.Id == request.ReceiptId, "User");

        if (receipt.ApprovalDate.Date > DateTime.Today.Date && receipt.Status == ReceiptStatus.Pending)
        {
            receipt.User!.Pending -= receipt.Points;
            receipt.User!.Pending += request.Points;
        }
        else
        {
            receipt.User!.Remaining -= receipt.Points;
            receipt.User!.Remaining += request.Points;
            receipt.User!.Total -= receipt.Points;
            receipt.User!.Total += request.Points;
        }

        receipt.Status = request.Status;
        receipt.Points = request.Points;
        await _receiptRepository.SaveAsync();
        return new ApiResponse();
    }

    public async Task<ApiResponse> ApproveAsync()
    {
        var receipts = await _receiptRepository.GetAllAsync(x =>
                x.ApprovalDate <= DateTime.Now && x.Status == ReceiptStatus.Pending,
            includes: nameof(User));
        var receiptsList = await receipts.ToListAsync();
        foreach (var receipt in receiptsList)
        {
            // check from kassa
            receipt.Status = receipt.Points == 0 ? ReceiptStatus.Rejected : ReceiptStatus.Approved;
            receipt.User!.Pending -= receipt.Points;
            receipt.User!.Total += receipt.Points;
            receipt.User!.Remaining += receipt.Points;
        }

        await _receiptRepository.SaveAsync();
        return new ApiResponse();
    }


    private List<Claim> GetClaims()
    {
        return _contextAccessor.HttpContext.User.Claims.ToList();
    }
}