using Ecommerce_backend.Repositories.AddressRepository;
using Ecommerce_backend.Repositories.AuthRepository;
using Ecommerce_backend.Repositories.CommentRepository;
using Ecommerce_backend.Repositories.ProductRepository;
using Ecommerce_backend.Services.AuthServices;
using Ecommerce_backend.Services.CommentService;
using Ecommerce_backend.Services.PasswordHash;
using Ecommerce_backend.Services.ProductServices;
using Ecommerce_backend.Services.TokenService;
using Ecommerce_backend.UnitOfWork.RegisterUserUOW;
using Ecommerce_backend.UnitOfWorks;


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
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IComService, ComService>();
            services.AddScoped<IComRepository, ComRepository>();
            services.AddScoped<IComService, ComService>();
            services.AddScoped<IComRepository, ComRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWorkService >();


            return services;
        }
    }
}
            