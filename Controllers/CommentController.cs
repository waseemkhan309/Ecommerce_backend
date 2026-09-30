using Ecommerce_backend.DTOs.CommentDTOs;
using Ecommerce_backend.Services.CommentService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentController(
        IComService comService
        ) : ControllerBase
    {
        private readonly IComService _comService = comService;

        [HttpGet]
        [Route("{prodId:guid}")]
        public async Task<IActionResult> comments([FromRoute] Guid prodId)
        {
            var response = await _comService.BuyersCommentList(prodId);
            return Ok(new
            {
                success = true,
                message = "Successfully Comments fetched.",
                data = response
            });
        }

        // POST Method
        // create Comment
        [HttpPost]
        public async  Task<IActionResult> comment([FromBody] CreateCommentDto comment)
        {
            var commentResult = await _comService.CreateCommentService(comment);

            return Ok(new
            {
                success = true,
                message = "Successfully Comment Created.",
                data = commentResult
            });
        }
    }
}
