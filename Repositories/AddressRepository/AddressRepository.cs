
using Ecommerce_backend.Data;
using Ecommerce_backend.Models;

namespace Ecommerce_backend.Repositories.AddressRepository
{
    public class AddressRepository(
        ApplicationDbContext applicationDbContext

    ) : IAddressRepository
    {
        private ApplicationDbContext _DbContext = applicationDbContext;

        public async Task<Address> AddUserAddress(Address address)
        {
            await _DbContext.Address.AddAsync(address);
            return address;
        }
    }
}
