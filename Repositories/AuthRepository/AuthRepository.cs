using Ecommerce_backend.Data;
using Ecommerce_backend.Models;

namespace Ecommerce_backend.Repositories.AuthRepository
{
    public class AuthRepository(ApplicationDbContext context) : IAuthRepository
    {
        private readonly ApplicationDbContext _Dbcontext = context;

        public async Task<Seller> RegisterSellerRepository(Seller seller)
        {
                await _Dbcontext.Seller.AddAsync(seller);
                return seller;
        }
    }
}
