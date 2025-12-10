using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Threading.Tasks;
using WebShop_Shared.Model.Binding.Common;
using WebShop_Shared.Model.Binding.OrderModels;
using WebShop_Shared.Model.Dto;
using WebShop_Shared.Model.ViewModel.Common;
using WebShop_WebApp.Services.Interfaces;

namespace WebShop_WebApp.Controllers
{
    [Authorize(Roles = Roles.Buyer)]
    public class BuyerController : Controller
    {
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IAccountService _accountService;
        public static string OrderItemSessionKey = "OrderItems";

        public BuyerController(IProductService productService, IOrderService orderService, IAccountService accountService)
        {
            _productService = productService;
            _orderService = orderService;
            this._accountService = accountService;
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
        public async Task<IActionResult> Order()
        {
            var sessionOrderItems = HttpContext.Session.GetString(OrderItemSessionKey);
            List<OrderItemBinding> existingOrderItems = sessionOrderItems != null ?
                JsonSerializer.Deserialize<List<OrderItemBinding>>(sessionOrderItems)!
                : new List<OrderItemBinding>();

            var userAddress = await _accountService.GetUserAddress<AddressBinding>(User);

            var response = new OrderBinding
            {
                OrderItems = existingOrderItems,
                OrderAddress = userAddress
            };


            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Order(OrderBinding model)
        {
            await _orderService.AddOrder(model, User);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> AddToOrderItem([FromBody] List<OrderItemBinding> orderItems)
        {
            try
            {
                var sessionOrderItems = HttpContext.Session.GetString(OrderItemSessionKey);
                List<OrderItemBinding> existingOrderItems = sessionOrderItems != null ?
                    JsonSerializer.Deserialize<List<OrderItemBinding>>(sessionOrderItems)!
                    : new List<OrderItemBinding>();

                foreach (var newItem in orderItems)
                {
                    var existingItem = existingOrderItems
                        .FirstOrDefault(oi => oi.ProductId == newItem.ProductId);

                    if (existingItem != null)
                    {
                        existingItem.Quantity += newItem.Quantity;
                    }
                    else
                    {
                        existingOrderItems.Add(newItem);
                    }
                }


                HttpContext.Session.SetString(OrderItemSessionKey, JsonSerializer.Serialize(existingOrderItems));
                return Json(existingOrderItems);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        public async Task<IActionResult> Orders()
        {
            var orders = await _orderService.GetOrders(User);
            return View(orders);
        }
        public async Task<IActionResult> UpdateOrderAddress(long orderId)
        {
            //var address = await _accountService.GetUserAddress<AddressViewModel>(User);

            var order = await _orderService.GetOrder(orderId);
            var address = await _accountService.GetAddress(order.OrderAddress.Id);
            address.OrderId = orderId;
            return View(address);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOrderAddress(AddressUpdateBinding model)
        {
            await _accountService.UpdateAddress(model);
            return RedirectToAction("OrderDetails", new { id = model.OrderId });
        }


        public async Task<IActionResult> OrderDetails(long id)
        {
            var order = await _orderService.GetOrder(id);
            return View(order);
        }

        public async Task<IActionResult> CanceleOrder(long id)
        {

            await _orderService.UpdateOrderStatus(new OrderStatusUpdateBinding
            {
                OrderId = id,
                OrderStatus = OrderStatus.Canceled
            });

            return RedirectToAction("Orders");
        }


    }
}
