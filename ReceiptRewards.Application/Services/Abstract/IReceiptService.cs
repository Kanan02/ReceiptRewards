using ReceiptRewards.Domain.Entities;
using ReceiptRewards.Domain.Requests;
using ReceiptRewards.Domain.Responses;

namespace ReceiptRewards.Application.Services.Abstract;

public interface IReceiptService
{
    Task<ApiValueResponse<List<Receipt>>> GetReceiptsWithFilter(ReceiptFilterRequest request);
    Task<ApiValueResponse<List<Receipt>>> GetReceiptsForApprovalAsync();
    Task<ApiValueResponse<List<Receipt>>> GetReceiptsAsync();
    Task<ApiResponse> AddAsync(ReceiptAddRequest receipt);    
    Task<ApiResponse> UpdateAsync(UpdateReceiptRequest request);
    Task<ApiResponse> ApproveAsync();

}