using ReceiptRewards.Domain.Entities;
using ReceiptRewards.Domain.Requests;
using ReceiptRewards.Domain.Responses;

namespace ReceiptRewards.Application.Services.Abstract
{
    public interface IPropertyService
    {
        Task<ApiValueResponse<AdditionalProperty>> GetInsta(StatisticsRequest statisticsRequest);
        Task<ApiResponse> UpdateInstaAsync();
        Task<ApiValueResponse<AdditionalProperty>> GetInstaSub();
    }
}
