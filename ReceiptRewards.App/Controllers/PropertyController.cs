using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReceiptRewards.Domain.Requests;
using ReceiptRewards.Domain.Responses;
using ReceiptRewards.Application.Services.Abstract;
using ReceiptRewards.Domain.Entities;
namespace ReceiptRewards.App.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PropertyController
    {
        private readonly IPropertyService _propertiesService;
        public PropertyController(IPropertyService propertiesService)
        {
            _propertiesService = propertiesService;
        }
        [HttpGet]
        [Authorize(Roles = "User,Admin")]
        public async Task<ApiValueResponse<AdditionalProperty>> GetInstaCount([FromQuery] StatisticsRequest statisticsRequest) => await _propertiesService.GetInsta(statisticsRequest);
        [HttpGet]
        [Authorize(Roles = "User,Admin")]
        public async Task<ApiValueResponse<AdditionalProperty>> GetInstaSubCount() => await _propertiesService.GetInstaSub();
        [HttpPut]
        public async Task<ApiResponse> IncrementInstaCount() =>
            await _propertiesService.UpdateInstaAsync();
    }
}
