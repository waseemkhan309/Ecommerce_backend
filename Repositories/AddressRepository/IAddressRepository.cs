using Ecommerce_backend.Models;

namespace Ecommerce_backend.Repositories.AddressRepository
{
    public interface IAddressRepository
    {
        Task AddUserAddress(Address address);
    }
}
