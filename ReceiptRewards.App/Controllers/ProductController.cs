using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReceiptRewards.Application.Services.Abstract;
using ReceiptRewards.Domain.Entities;
using ReceiptRewards.Domain.Responses;

namespace ReceiptRewards.App.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ApiValueResponse<List<ProductResponse>>> GetUniqueProducts() => await _productService.GetUniqueProductsAsync();
    }
}
