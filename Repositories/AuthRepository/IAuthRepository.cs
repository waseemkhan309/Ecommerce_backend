
using Ecommerce_backend.Models;

namespace Ecommerce_backend.Repositories.AuthRepository
{
    public interface IAuthRepository
    {
        public Task<Buyer?> GetUserByEmail(string email);

        // Buyer Register
        public Task RegisterBuyerRepository(Buyer buyer);

        // Seller register
    }
}
