
using Ecommerce_backend.Models;
using Ecommerce_backend.Repositories.AddressRepository;
using Ecommerce_backend.Repositories.AuthRepository;

namespace Ecommerce_backend.UnitOfWork.RegisterUserUOW
{
    public class RegisterUserUOW(
        IAuthRepository authRepository,
        IAddressRepository addressRepository
    ) : IRegisterUserUOW
    {
        private readonly IAuthRepository _authRepository = authRepository;
        private readonly IAddressRepository _addressRepository = addressRepository;


        public async Task RegisterBuyerWithAddress(Buyer buyer, Address address)
        {
            await _authRepository.RegisterBuyerRepository(buyer);
            await _addressRepository.AddUserAddress(address);
        }
    }
}
