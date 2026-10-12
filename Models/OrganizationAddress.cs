namespace Ecommerce_backend.Models
{
    public class OrganizationAddress : BaseEntity
    {
        public string OrgAddress { get; set; } = string.Empty;
        public string OrgCity { get; set; } = string.Empty;
        public string OrgState { get; set; } = string.Empty;
        public string OrgCountry { get; set; } = string.Empty;

        public Guid OrganizationId { get; set; }
        public Organization Organization { get; set; } = new Organization();
    }
}
