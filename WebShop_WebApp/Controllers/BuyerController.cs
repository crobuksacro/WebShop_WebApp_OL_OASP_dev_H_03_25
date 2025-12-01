using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebShop_Shared.Model.Binding.OrderModels;
using WebShop_Shared.Model.Dto;
using WebShop_WebApp.Services.Interfaces;

namespace WebShop_WebApp.Controllers
{
    [Authorize(Roles = Roles.Buyer)]
    public class BuyerController : Controller
    {
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;


        public BuyerController(IProductService productService, IOrderService orderService)
        {
            _productService = productService;
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _productService.GetAllProductCategorys();
            return View(categories);
        }


        public async Task<IActionResult> Category(long id)
        {
            var category = await _productService.GetByIdProductCategory(id);
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Order(OrderBinding model)
        {
            await _orderService.AddOrder(model, User);
            return RedirectToAction("Index");
        }


    }
}
