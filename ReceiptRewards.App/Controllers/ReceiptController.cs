using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReceiptRewards.Application.Services.Abstract;
using ReceiptRewards.Domain.Entities;
using ReceiptRewards.Domain.Requests;
using ReceiptRewards.Domain.Responses;

namespace ReceiptRewards.App.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReceiptController : ControllerBase
    {
        private readonly IReceiptService _receiptService;

        public ReceiptController(IReceiptService receiptService)
        {
            _receiptService = receiptService;
        }

        [HttpPost]
        [Authorize(Roles = "User,Admin")]
        public async Task<ApiResponse> Add(ReceiptAddRequest receiptRequest) =>
            await _receiptService.AddAsync(receiptRequest);

        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public async Task<ApiValueResponse<List<Receipt>>> AllByUser() =>
            await _receiptService.GetReceiptsAsync();

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ApiValueResponse<List<Receipt>>> ApprovalList() =>
            await _receiptService.GetReceiptsForApprovalAsync();

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ApiResponse> Update(UpdateReceiptRequest request) =>
            await _receiptService.UpdateAsync(request);

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ApiValueResponse<List<Receipt>>> AllWithFilter(
            [FromQuery] ReceiptFilterRequest request
        ) => await _receiptService.GetReceiptsWithFilter(request);

      
    }
}
