using Ecommerce_backend.DTOs.ProductDTOs;
using Ecommerce_backend.Models;

namespace Ecommerce_backend.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<ProductDto?>> ProductListRepo();
    }
}


