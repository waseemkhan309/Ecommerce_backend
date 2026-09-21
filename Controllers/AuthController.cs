using Ecommerce_backend.DTOs.AuthDTOs;
using Ecommerce_backend.Services.AuthServices;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(
        IAuthServices authServices
    ) : ControllerBase
    {
        private IAuthServices _authServices = authServices;

        [HttpPost]
        [Route("seller")]
        public async Task<IActionResult> registerSeller([FromBody] RegisterSellerRequestDto registerSellerRequestDto)
        {
           
            RegisterUserResponseDto  result = await _authServices.RegisterSellerService(registerSellerRequestDto);
            return Ok(new { message = "Successfully Seller User created.", success = true, data = result });

        }

        [HttpPost]
        [Route("seller/login")]
        public async Task<IActionResult> loginSeller([FromBody] SellerUserLoginRequest sellerUserLoginRequest)
        {
            
            // call the service and repository
            var res = await _authServices.LoginSellerService(sellerUserLoginRequest);

            // return login seller response
            return Ok(new
            {
                message = "Successfully Login.",
                success = true,
                data = res
            }
            );
        }
    }
}
