using Ecommerce_backend.Data;
using Ecommerce_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_backend.Repositories.AuthRepository
{
    public class AuthRepository(ApplicationDbContext context) : IAuthRepository
    {
        private readonly ApplicationDbContext _Dbcontext = context;

        public async Task RegisterBuyerRepository(Buyer buyer)
        {
             await _Dbcontext.Buyer.AddAsync(buyer);
        }


        // find User by Email
        public async Task<Buyer?> GetUserByEmail(string email)
        {
            return await _Dbcontext.Buyer
                         .AsNoTracking()
                         .FirstOrDefaultAsync(e => e.Email == email);
        }
    }
}
