using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebShop_Shared.Model.Dto;
using WebShop_WebApp.Services.Interfaces;

namespace WebShop_WebApp.Controllers
{


    [Authorize(Roles = Roles.Admin + "," + Roles.Buyer)]
    public class OrderController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOrderService _orderService;

        public OrderController(ILogger<HomeController> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }


        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> AdminOrders()
        {
            var orders = await _orderService.GetOrders();
            return View(orders);
        }

        public async Task<IActionResult> BuyerOrders()
        {
            var orders = await _orderService.GetOrders(User);
            return View(orders);
        }


    }
}
