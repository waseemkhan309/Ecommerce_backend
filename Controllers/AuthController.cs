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
        [Route("buyer/register")]
        public async Task<IActionResult> registerSeller([FromBody] BuyerRegisterRequestDto registerSellerRequestDto)
        {
           
            await _authServices.BuyerRegisterService(registerSellerRequestDto);
            return Ok(new { message = "Successfully Seller User created.", success = true });

        }

        [HttpPost]
        [Route("buyer/login")]
        public async Task<IActionResult> loginSeller([FromBody] BuyerLoginRequest sellerUserLoginRequest)
        {
            
            // call the service and repository
            var res = await _authServices.BuyerLoginService(sellerUserLoginRequest);

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
