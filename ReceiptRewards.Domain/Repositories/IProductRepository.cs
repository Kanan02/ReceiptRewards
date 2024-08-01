using ReceiptRewards.Domain.Entities;
using ReceiptRewards.Domain.Responses;
using System.Linq.Expressions;
using ReceiptRewards.Domain.Requests;

namespace ReceiptRewards.Domain.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        public Task<List<ProductResponse>> GetUniqueProductsAsync();
        public Task<List<ProductResponse>> GetUniqueProductsFilteredAsync(ProductFilterRequest statisticsRequest);
    }
}
