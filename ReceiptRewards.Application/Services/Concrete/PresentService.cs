using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ReceiptRewards.Application.Services.Abstract;
using ReceiptRewards.Domain.Entities;
using ReceiptRewards.Domain.Repositories;
using ReceiptRewards.Domain.Requests;
using ReceiptRewards.Domain.Responses;
using System.Security.Claims;

namespace ReceiptRewards.Application.Services.Concrete
{
    public class PresentService : IPresentService
    {
        private readonly IPresentRepository _presentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _contextAccessor;

        public PresentService(IPresentRepository presentRepository, IHttpContextAccessor contextAccessor, IUserRepository userRepository)
        {
            _presentRepository = presentRepository;
            _contextAccessor = contextAccessor;
            _userRepository = userRepository;
        }

        public async Task<ApiValueResponse<List<PresentDto>>> GetAllAsync()
        {
            var query = await _presentRepository.GetAllAsync();
            var list = await query.Select(x => new PresentDto(x)).ToListAsync();
            return new ApiValueResponse<List<PresentDto>>( list);
        }

        public async Task<ApiResponse> UpdateAsync(UpdatePresentRequest request)
        {
            var present = await _presentRepository.GetAsync(x => x.Id == request.PresentId);
            present.Quantity = request.Quantity;
            present.Price = request.Price;
            await _presentRepository.SaveAsync();
            return new ApiResponse();
        }
        public async Task<ApiResponse> BuyAsync(BuyPresentRequest request)
        {
            var userId = int.Parse(GetClaims().FirstOrDefault(x => x.Type == "userId")!.Value);
           
            var present = await _presentRepository.GetAsync(x => x.Id == request.PresentId);
            var user = await _userRepository.GetAsync(x => x.Id == userId,includes:nameof(User.Presents));
            if (user.Remaining<present.Price)
                return new ApiResponse(
                    new ApiError { ErrorCode = "notEnoughMoney", ErrorMsg = "Not enough money to buy this present" }
                );
            if (present.Quantity<1)
                return new ApiResponse(
                    new ApiError { ErrorCode = "outOfStock", ErrorMsg = "This product is out of stock" }
                );
            user.Remaining -= present.Price;
            present.Quantity--;
            user.Spent += present.Price;
            user.Presents!.Add(present);
            await _userRepository.SaveAsync();
            return new ApiResponse();
        }
        private List<Claim> GetClaims()
        {
            return _contextAccessor.HttpContext.User.Claims.ToList();
        }
    }
}
