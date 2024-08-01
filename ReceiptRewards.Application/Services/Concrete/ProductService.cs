using ReceiptRewards.Application.Services.Abstract;
using ReceiptRewards.Domain.Entities;
using ReceiptRewards.Domain.Repositories;
using ReceiptRewards.Domain.Requests;
using ReceiptRewards.Domain.Responses;

namespace ReceiptRewards.Application.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ApiValueResponse<List<ProductResponse>>> GetUniqueProductsAsync()
        {
            return new ApiValueResponse<List<ProductResponse>>( await _productRepository.GetUniqueProductsAsync());
        }

        public async Task<ApiValueResponse<List<ProductResponse>>> GetUniqueProductsFilteredAsync(ProductFilterRequest request)
        {
            return new ApiValueResponse<List<ProductResponse>>( await _productRepository.GetUniqueProductsFilteredAsync(request));
        }
    }
}
