using Ecommerce_backend.DTOs.AuthDTOs.Seller;
using Ecommerce_backend.Services.SellerAuthService;
using Microsoft.AspNetCore.Mvc;


namespace Ecommerce_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerAuthController(
        ISellerAuthService sellerAuthService
        ) : ControllerBase
    {
        private readonly ISellerAuthService _sellerAuthService = sellerAuthService;

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> SellerRegister([FromBody] SellerRegisterRequestDto sellerRequest)
        {
            if (sellerRequest == null)
            {
                return BadRequest("Request cannot be null.");
            }
            try
            {
                var sellerRegisteredId = await _sellerAuthService.SellerRegisterService(sellerRequest);
                return Ok( new
                {
                    success = true,
                    message = "Seller registered successfully.",
                    sellerId = sellerRegisteredId
                });
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        // seller login
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> SellerLogin(SellerLoginRequestDto sellerReqDto) 
        {
            var sellerLoginResponse = await _sellerAuthService.SellerLoginService(sellerReqDto);

            return Ok(new
            {
                success = true,
                message = "Seller Successfully registered.",
                data = sellerLoginResponse
            });

        }

    }
}
