using ReceiptRewards.Domain.Requests;
using ReceiptRewards.Domain.Responses;

namespace ReceiptRewards.Application.Services.Abstract
{
    public interface IPresentService
    {
        Task<ApiValueResponse<List<PresentDto>>> GetAllAsync();
        Task<ApiResponse> UpdateAsync(UpdatePresentRequest request);
        Task<ApiResponse> BuyAsync(BuyPresentRequest request);
    }
}
