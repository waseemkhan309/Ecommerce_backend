using Ecommerce_backend.Data;
using Ecommerce_backend.Models;

namespace Ecommerce_backend.Repositories.OrganizationRepository
{
    public class OrganizationRepository(
        ApplicationDbContext context
        ) : IOrganizationRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task SellerOrganization(Organization organization)
        {
            await _context.Organizations.AddAsync(organization);
        }

        public async Task SellerOrganizationAddress(OrganizationAddress organizationAddress)
        {
            await _context.OrgAddress.AddAsync(organizationAddress);
        }

    }
}
