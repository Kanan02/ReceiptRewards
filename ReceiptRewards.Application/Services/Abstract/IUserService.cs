using ReceiptRewards.Domain.Entities;
using ReceiptRewards.Domain.Requests;
using ReceiptRewards.Domain.Requests.Pagination;
using ReceiptRewards.Domain.Responses;

namespace ReceiptRewards.Application.Services.Abstract;

public interface IUserService
{
    Task<ApiValueResponse<List<UserResponse>>> GetUsersByFilter(UserFilterRequest request);
    Task<ApiResponse> RegisterAsync(RegisterRequest user);
    Task<ApiValueResponse<string>> LoginAsync(LoginRequest request);
    Task<ApiValueResponse<UserResponse>> GetUserInfoAsync();
    Task<ApiValueResponse<UserResponse>> PutUserInfoAsync(UserPutRequest user);
    Task<ApiResponse> SendPassword(string msisdn);
    // Task<ApiValueResponse<Receipt>> GetUserByCode(string code);
    Task<ApiResponse> ChangePasswordAsync(ChangePasswordRequest request);
    Task<ApiResponse> VerifyOtp(CheckOtpRequest request);
}
