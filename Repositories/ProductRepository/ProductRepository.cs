using Ecommerce_backend.Data;
using Ecommerce_backend.DTOs.ProductDTOs;
using Ecommerce_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_backend.Repositories.ProductRepository
{
    public class ProductRepository(
        ApplicationDbContext applicationDbContext
        ) : IProductRepository
    {
        // Data members
        private ApplicationDbContext _dbContext = applicationDbContext;


        // Function members 
        public async Task<List<ProductDto>> ProductListRepo()
        {
            return await _dbContext.Product
                .AsNoTracking()
                .Select(p => new ProductDto(
                    p.Id,
                    p.Name,
                    p.Description,
                    p.Price,
                    p.Discount,
                    p.Stock,
                    new CategoryDto(p.Category.Id, p.Category.Name, p.Category.Description),
                    p.ProductImages.Select(i => i.ImageUrl).ToList(),
                    p.CreatedAt,
                    p.UpdatedAt))
                .ToListAsync();
        }
    }
}
