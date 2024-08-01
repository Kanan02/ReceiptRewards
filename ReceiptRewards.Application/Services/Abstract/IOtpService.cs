using ReceiptRewards.App.Helpers;
using ReceiptRewards.Domain.Requests;
using ReceiptRewards.Domain.Responses;

namespace ReceiptRewards.Application.Services.Abstract;

public interface IOtpService
{
    Task<ApiValueResponse<int>> GetPin(OtpRequest request);
    Task<ApiResponse> CheckPin(CheckOtpRequest req);
    Task<ApiValueResponse<bool>> GenerateCode(OtpRequest request);
}
