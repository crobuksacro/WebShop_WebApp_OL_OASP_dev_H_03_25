using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebShop_Api.FluentValidation;
using WebShop_Api.Services.Interfaces;
using WebShop_Shared.Model.Binding.ProductModels;
using WebShop_Shared.Model.ViewModel.ProductModels;

namespace WebShop_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;
        private readonly IValidator<ProductBinding> _productBindingValidator;
        private readonly IValidator<ProductUpdateBinding> _productUpdateBindingValidator;
        private readonly IValidator<ProductCategoryIdBinding> _productCategoryIdBindingValidator;

        public ProductController(ILogger<ProductController> logger,
            IProductService productService,
            IValidator<ProductBinding> productBindingValidator,
            IValidator<ProductUpdateBinding> productUpdateBindingValidator,
            IValidator<ProductCategoryIdBinding> productCategoryIdBindingValidator)
        {
            _logger = logger;
            _productService = productService;
            _productBindingValidator = productBindingValidator;
            _productUpdateBindingValidator = productUpdateBindingValidator;
            _productCategoryIdBindingValidator = productCategoryIdBindingValidator;
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


        /// <summary>
        /// Adds a new product to the database.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ProductViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Add([FromBody] ProductBinding model)
        {

            var result = await _productBindingValidator.ValidateAsync(model);
            if (result.IsValid)
            {
                return Ok(await _productService.Add(model));
            }

            return BadRequest(result.Errors);

        }


        /// <summary>
        /// Updates an existing product.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(ProductViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] ProductUpdateBinding model)
        {
            var result = await _productUpdateBindingValidator.ValidateAsync(model);
            if (result.IsValid)
            {
                return Ok(await _productService.Update(model));
            }

            return BadRequest(result.Errors);
        }
        /// <summary>
        /// Deletes a product by setting its Valid property to false. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(ProductViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(long id)
        {
            return Ok(await _productService.Delete(id));
        }

        /// <summary>
        /// Adds a new product category to the database.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("categorie")]
        [ProducesResponseType(typeof(ProductCategoryViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddProductCategory([FromBody] ProductCategoryBinding model)
        {
            return Ok(await _productService.AddProductCategory(model));
        }
        /// <summary>
        /// Gets all product categories.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("categorie")]
        [ProducesResponseType(typeof(ProductCategoryViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] ProductCategoryUpdateBinding model)
        {
            return Ok(await _productService.UpdateProductCategory(model));
        }

        /// <summary>
        /// Deletes a product category by setting its Valid property to false.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("categorie/{id}")]
        [ProducesResponseType(typeof(ProductCategoryViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteProductCategory(ProductCategoryIdBinding model)
        {
            var result = await _productCategoryIdBindingValidator.ValidateAsync(model);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            return Ok(await _productService.DeleteProductCategory(model.Id));
        }

        /// <summary>
        /// Gets all product categories.
        /// </summary>
        /// <returns></returns>
        [HttpGet("categories")]
        [ProducesResponseType(typeof(List<ProductCategoryViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllProductCategorys()
        {
            return Ok(await _productService.GetAllProductCategorys());
        }

        /// <summary>
        /// Gets a product category by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("categorie/{id}")]
        [ProducesResponseType(typeof(ProductCategoryViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdProductCategory(long id)
        {

            var result = await _productCategoryIdBindingValidator.ValidateAsync(new ProductCategoryIdBinding { Id = id });
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            return Ok(await _productService.GetByIdProductCategory(id));
        }
    }
}
