using Ecommerce_backend.Models;

namespace Ecommerce_backend.UnitOfWork.RegisterUserUOW
{
    public interface IRegisterUserUOW
    {
        Task<Seller> RegisterUserAndAddress(Seller seller, Address address);
    }
}
