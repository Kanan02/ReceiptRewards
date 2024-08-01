using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReceiptRewards.Application.Services.Abstract;
using ReceiptRewards.Domain.Requests;
using ReceiptRewards.Domain.Requests.Pagination;
using ReceiptRewards.Domain.Responses;

namespace ReceiptRewards.App.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ApiValueResponse<List<UserResponse>>> All(
          [FromQuery] UserFilterRequest request
        ) => await _userService.GetUsersByFilter(request);

        [HttpPost]
        public async Task<ApiResponse> Register(RegisterRequest user) =>
            await _userService.RegisterAsync(user);

        [HttpPut]
        public async Task<ApiResponse> UserInfo(UserPutRequest user) =>
            await _userService.PutUserInfoAsync(user);
        
        
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var response = await _userService.LoginAsync(request);

            if (response.Errors.Count != 0)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<ApiValueResponse<UserResponse>> UserInfo() =>
            await _userService.GetUserInfoAsync();
        
        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<ApiResponse> ChangePassword(
            ChangePasswordRequest request
        ) => await _userService.ChangePasswordAsync(request);

        [HttpGet]
        public async Task<ApiResponse> SendPassword([FromQuery] string msisdn) =>
            await _userService.SendPassword(msisdn);

        [HttpPost]
        public async Task<ApiResponse> VerifyOtp(CheckOtpRequest request) =>
            await _userService.VerifyOtp(request);
    }
}
