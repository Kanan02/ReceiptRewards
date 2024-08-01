using ReceiptRewards.Domain.Entities;
using ReceiptRewards.Domain.Requests;
using ReceiptRewards.Domain.Responses;

namespace ReceiptRewards.Application.Services.Abstract
{
    public interface IProductService
    {
        Task<ApiValueResponse<List<ProductResponse>>> GetUniqueProductsAsync();
        
        Task<ApiValueResponse<List<ProductResponse>>> GetUniqueProductsFilteredAsync(ProductFilterRequest request);
    }
}
