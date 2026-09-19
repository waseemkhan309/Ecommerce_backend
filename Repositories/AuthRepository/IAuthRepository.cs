
using Ecommerce_backend.Models;

namespace Ecommerce_backend.Repositories.AuthRepository
{
    public interface IAuthRepository
    {
        public Task<Seller> RegisterSellerRepository(Seller seller); 
    }
}
