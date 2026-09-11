namespace Ecommerce_backend.Models
{
    public class Organization : BaseEntity
    {
        public string OrgainationURL { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        
        // Buyer have one Organization, and Organization belongs to one Buyer
        public Guid BuyerId { get; set; }
        public Buyer Buyer { get; set; } = new Buyer();

        // Navigation property for the products associated with the buyer
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
