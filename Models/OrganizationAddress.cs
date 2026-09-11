namespace Ecommerce_backend.Models
{
    public class OrganizationAddress : BaseEntity
    {
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;  
        public string Area { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        public ICollection<Organization> OrganizationAddresses { get; set; } = new List<Organization>();
    }
}
