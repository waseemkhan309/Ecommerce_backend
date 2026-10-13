using Ecommerce_backend.Data;
using Ecommerce_backend.DTOs.AuthDTOs.Seller;
using Ecommerce_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_backend.Repositories.SellerAuthRepository
{
    public class SellerAuthRepo(
        ApplicationDbContext dbContext
        ) : ISellerAuthRepo
    {
         
        private readonly ApplicationDbContext _dbContext = dbContext;

        public async Task<Seller?> SellerGetByEmail(string email)
        {
            return await _dbContext.Seller
                             .Where(s => s.Email == email)
                             .Select(s => new Seller
                             {
                                 Id = s.Id,
                                 UserName = s.UserName,
                                 FirstName = s.FirstName,
                                 LastName = s.LastName,
                                 Email = s.Email,
                                 PhoneNumber = s.PhoneNumber,
                                 IsEmailVerified = s.IsEmailVerified,
                                 PasswordHash = s.PasswordHash,
                                 IsPhoneNumberVerified = s.IsPhoneNumberVerified,
                                 Country = s.Country,
                                 Gender = s.Gender,
                                 CreatedAt = s.CreatedAt,
                                 UpdatedAt = s.UpdatedAt
                             })
                             .FirstOrDefaultAsync();
                
        }

        public async Task<Seller?> SellerGetById(Guid id)
        {
            return await _dbContext.Seller
                             .Where(s => s.Id == id)
                             .Select(s => new Seller
                             {
                                 Id = s.Id,
                                 UserName = s.UserName,
                                 FirstName = s.FirstName,
                                 LastName = s.LastName,
                                 Email = s.Email,
                                 PhoneNumber = s.PhoneNumber,
                                 IsEmailVerified = s.IsEmailVerified,
                                 IsPhoneNumberVerified = s.IsPhoneNumberVerified,
                                 Country = s.Country,
                                 Gender = s.Gender,
                                 CreatedAt = s.CreatedAt,
                                 UpdatedAt = s.UpdatedAt
                             })
                             .FirstOrDefaultAsync();

        }

        
        public async Task SellerRegisterRepo(Seller seller)
        {
            await _dbContext.Seller.AddAsync(seller);
        }

    }
}

