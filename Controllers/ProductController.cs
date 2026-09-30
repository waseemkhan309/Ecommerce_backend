using Ecommerce_backend.Services.ProductServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController(
        IProductService productService
        ) : ControllerBase
    {
        private IProductService _productService = productService;

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            try
            {
                var productListResult = await _productService.ProductListService();

                return Ok(new
                {
                    success = true,
                    message = "Successfully products fetched",
                    data = productListResult,
                });
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
