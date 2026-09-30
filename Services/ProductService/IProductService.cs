
using Ecommerce_backend.DTOs.ProductDTOs;

namespace Ecommerce_backend.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ProductDto?>> ProductListService();
    }
}

