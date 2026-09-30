
namespace Ecommerce_backend.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int Stock { get; set; }

        // Category
        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        // Organization
        public Guid OrganizationId { get; set; }
        public Organization Organization { get; set; } = null!;

        // Seller Products
        public Guid SellerId { get; set; }
        public Seller Seller { get; set; } = new Seller();
        
        // ProductImages Navigation
        public ICollection<ProductImages> ProductImages { get; set; } = new List<ProductImages>();

    }
}
