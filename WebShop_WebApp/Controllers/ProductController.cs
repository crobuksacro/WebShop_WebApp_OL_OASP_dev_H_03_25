using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebShop_Shared.Model.Binding;
using WebShop_WebApp.Services.Interfaces;

namespace WebShop_WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public async Task<IActionResult> Categorys()
        {
            var categories = await _productService.GetAllProductCategorys();
            return View(categories);
        }

        public async Task<IActionResult> CreateCategorys()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateCategorys(ProductCategoryBinding model)
        {
            var categories = await _productService.AddProductCategory(model);
            return RedirectToAction("Categorys");
        }

        public async Task<IActionResult> Category(long id)
        {
            var category = await _productService.GetByIdProductCategory(id);
            return View(category);
        }

        public async Task<IActionResult> EditCategory(long id)
        {
            var category = await _productService.GetByIdProductCategory(id);
            return View(category);
        }


        [HttpPost]
        public async Task<IActionResult> EditCategory(ProductCategoryUpdateBinding model)
        {
            var categories = await _productService.UpdateProductCategory(model);
            return RedirectToAction("Categorys");
        }

        public async Task<IActionResult> DeleteCategory(long id)
        {
            var category = await _productService.DeleteProductCategory(id);
            return RedirectToAction("Categorys");
        }

    }
}
