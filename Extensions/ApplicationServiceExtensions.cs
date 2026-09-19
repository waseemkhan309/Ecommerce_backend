using Ecommerce_backend.Repositories.AddressRepository;
using Ecommerce_backend.Repositories.AuthRepository;
using Ecommerce_backend.Services.AuthServices;
using Ecommerce_backend.Services.PasswordHash;
using Ecommerce_backend.UnitOfWork.RegisterUserUOW;

namespace Ecommerce_backend.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Add application services here

            services.AddScoped<IPasswordHash, PasswordHash>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IRegisterUserUOW, RegisterUserUOW>();
            services.AddScoped<IAuthServices, AuthServices>();

            return services;
        }
    }
}
            