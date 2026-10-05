
using Ecommerce_backend.DTOs.CategoryDTOs;


namespace Ecommerce_backend.DTOs.ProductDTOs
{

    public record ProductDto(
        Guid Id,
        string Name,
        string Description,
        decimal Price,
        decimal Discount,
        int Stock,
        CategoryDto Category,          // DTO, no Products collection
        List<string> Images,
        DateTime CreatedAt,
        DateTime UpdatedAt);

}
