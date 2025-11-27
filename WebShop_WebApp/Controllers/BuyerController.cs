using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebShop_Shared.Model.Dto;
using WebShop_WebApp.Services.Interfaces;

namespace WebShop_WebApp.Controllers
{
    [Authorize(Roles = Roles.Buyer)]
    public class BuyerController : Controller
    {
        private readonly IProductService _productService;

        public BuyerController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _productService.GetAllProductCategorys();
            return View(categories);
        }

    }
}
