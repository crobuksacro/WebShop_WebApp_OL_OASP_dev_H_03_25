using Microsoft.AspNetCore.Mvc;

namespace WebShop_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }




        [HttpGet]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCurrentDate()
        {
            return Ok(/*_calendarService.GetCurrentDate()*/);
        }
    }
}
