
using Ecommerce_backend.Data;
using Ecommerce_backend.Models;
using Ecommerce_backend.Repositories.AddressRepository;
using Ecommerce_backend.Repositories.AuthRepository;

namespace Ecommerce_backend.UnitOfWork.RegisterUserUOW
{
    public class RegisterUserUOW(
        IAuthRepository authRepository,
        IAddressRepository addressRepository,
        ApplicationDbContext dbContext
        
    ) : IRegisterUserUOW
    {
        private readonly IAuthRepository _authRepository = authRepository;
        private readonly IAddressRepository _addressRepository = addressRepository;
        private readonly ApplicationDbContext _dbContext = dbContext;


        public async Task<Seller> RegisterUserAndAddress(Seller seller, Address address)
        {
            seller.Address = address;

            await _authRepository.RegisterSellerRepository(seller);
            await _addressRepository.AddUserAddress(address);

            await _dbContext.SaveChangesAsync();

            return seller;
        }
    }
}
