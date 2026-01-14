using Microsoft.AspNetCore.Mvc;
using WebShop_Api.Services.Interfaces;
using WebShop_Shared.Model.ViewModel.ProductModels;

namespace WebShop_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;
        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }



        /// <summary>
        /// Retrieves a list of product view models, optionally filtered by a set of product IDs.
        /// </summary>
        /// <returns></returns>
        [HttpGet("products")]
        [ProducesResponseType(typeof(List<ProductViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productService.GetAll());
        }
    }
}
