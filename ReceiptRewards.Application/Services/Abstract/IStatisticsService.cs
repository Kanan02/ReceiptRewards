using ReceiptRewards.Domain.Requests;
using ReceiptRewards.Domain.Responses;

namespace ReceiptRewards.Application.Services.Abstract
{
    public interface IStatisticsService
    {
        Task<ApiValueResponse<List<Statistic>>> GetStatisticsAsync(StatisticsRequest statisticsRequest);
    }
}
