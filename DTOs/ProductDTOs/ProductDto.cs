
namespace Ecommerce_backend.DTOs.ProductDTOs
{
    //public class ProductDto
    //{
    //    public Guid Id { get; set; }
    //    public string Name { get; set; } = string.Empty;
    //    public string Description { get; set; } = string.Empty;
    //    public decimal Price { get; set; }
    //    public decimal Discount { get; set; }
    //    public int Stock { get; set; }

    //    //public List<string> ImagesUrl { get; set; } = new List<string>();
    //    //public string Category { get; set; } = string.Empty;
    //    public DateTime CreatedAt { get; set; }
    //    public DateTime UpdatedAt { get; set; }



    //    public ProductDto(Guid id, string name, string description, decimal discount, decimal price, int stock, DateTime createdAt, DateTime updatedAt)
    //    {
    //        Id = id;
    //        Name = name;
    //        Description = description;
    //        Discount = discount;
    //        Price = price;
    //        Stock = stock;
    //        CreatedAt = createdAt;
    //        UpdatedAt = updatedAt;
            
    //    }
    //}


    public record CategoryDto(Guid Id, string Name, string Description);

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
