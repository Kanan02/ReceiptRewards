using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReceiptRewards.Application.Services.Abstract;
using ReceiptRewards.Application.Services.Concrete;
using ReceiptRewards.Domain.Entities;
using ReceiptRewards.Domain.Requests;
using ReceiptRewards.Domain.Responses;

namespace ReceiptRewards.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService _statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ApiValueResponse<List<Statistic>>> GetStatistics([FromQuery]StatisticsRequest statisticsRequest) =>
            await _statisticsService.GetStatisticsAsync(statisticsRequest);

    }
}
