using DocumentFormat.OpenXml.InkML;
using Microsoft.EntityFrameworkCore;
using ReceiptRewards.Domain.Entities;
using ReceiptRewards.Domain.Repositories;
using ReceiptRewards.Domain.Requests;
using ReceiptRewards.Domain.Responses;
using ReceiptRewards.Infrastructure.DataAccess.Contexts;

namespace ReceiptRewards.Infrastructure.DataAccess.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ReceiptRewardsAPIDbContext context) : base(context)
        {
        }

        public async Task<List<ProductResponse>> GetUniqueProductsAsync()
        {
            return await _context.Product
                       .GroupBy(p => p.Name)
                       .Select(g => new ProductResponse
                       {
                           Name = g.Key,
                           Quantity = g.Sum(p => p.Quantity),
                           TotalPrice =Math.Round( g.Sum(p => p.TotalPrice),2)
                       })
                       .ToListAsync();
        }

        public async Task<List<ProductResponse>> GetUniqueProductsFilteredAsync(ProductFilterRequest request)
        {
            return await _context.Product
                .Where(c=>c.CreatedAt >= request.StartDate && c.CreatedAt <= request.EndDate)
                .GroupBy(p => p.Name)
                .Select(g => new ProductResponse
                {
                    Name = g.Key,
                    Quantity = g.Sum(p => p.Quantity),
                    TotalPrice =Math.Round( g.Sum(p => p.TotalPrice),2)
                })
                .ToListAsync();
        }

       
    }
}
