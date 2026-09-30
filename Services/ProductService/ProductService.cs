using Ecommerce_backend.DTOs.ProductDTOs;
using Ecommerce_backend.Models;
using Ecommerce_backend.Repositories.ProductRepository;

namespace Ecommerce_backend.Services.ProductServices
{
    public class ProductService(
        IProductRepository productRepository
        ) : IProductService
    {

        // Data members
        private IProductRepository _productRepository = productRepository;

        // Function members
        public async Task<List<ProductDto?>> ProductListService()
        {
            return await _productRepository.ProductListRepo();
        } 
    }
}
