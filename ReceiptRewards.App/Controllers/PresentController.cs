using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReceiptRewards.Application.Services.Abstract;
using ReceiptRewards.Domain.Requests;
using ReceiptRewards.Domain.Responses;

namespace ReceiptRewards.App.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PresentController : ControllerBase
    {
        private readonly IPresentService _presentService;

        public PresentController(IPresentService presentService)
        {
            _presentService = presentService;
        }
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<ApiResponse> Update(UpdatePresentRequest request) =>
            await _presentService.UpdateAsync(request);
        [HttpGet]
        [Authorize(Roles = "User,Admin")]
        public async Task<ApiValueResponse<List<PresentDto>>> All() => await _presentService.GetAllAsync();
        [HttpPost]
        [Authorize(Roles = "User,Admin")]
        public async Task<ApiResponse> Buy(BuyPresentRequest request) => await _presentService.BuyAsync(request);

    }
}
