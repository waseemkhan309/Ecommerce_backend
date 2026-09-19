using Ecommerce_backend.DTOs.AuthDTOs;
using Ecommerce_backend.Services.AuthServices;
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
            try
            {
                RegisterUserResponseDto  result = await _authServices.RegisterSellerService(registerSellerRequestDto);
                return Ok(new { message = "Successfully Seller User created.", success = true, data = result });

            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
