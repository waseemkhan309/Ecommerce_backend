using Ecommerce_backend.Models;

namespace Ecommerce_backend.Repositories.OrganizationRepository
{
    public interface IOrganizationRepository
    {
        Task SellerOrganization(Organization organization);
        Task SellerOrganizationAddress(OrganizationAddress organizationAddress);
    }
}


