using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebShop_Shared.Model.Binding.OrderModels;
using WebShop_Shared.Model.Dto;
using WebShop_Shared.Model.ViewModel.OrderModels;
using WebShop_WebApp.Data;
using WebShop_WebApp.Models.Dbo;
using WebShop_WebApp.Models.Dbo.OrderModels;
using WebShop_WebApp.Services.Interfaces;

namespace WebShop_WebApp.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _dbo;
        private readonly IMapper _mapper;
        private UserManager<ApplicationUser> _userManager;

        public OrderService(ApplicationDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _dbo = context;
            _mapper = mapper;
            _userManager = userManager;
        }
        /// <summary>
        /// Updates the status of an existing order
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<OrderViewModel> UpdateOrderStatus(OrderStatusUpdateBinding model)
        {
            var dbo = await _dbo.Orders.FirstOrDefaultAsync(y => y.Id == model.OrderId);
            if (dbo == null)
            {
                return null;
            }

            dbo.OrderStatus = model.OrderStatus;
            await _dbo.SaveChangesAsync();
            return _mapper.Map<OrderViewModel>(dbo);
        }
        /// <summary>
        /// Adds a new order to the database
        /// </summary>
        /// <param name="model"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<OrderViewModel> AddOrder(OrderBinding model, ClaimsPrincipal user)
        {
            var applicationUser = await _userManager.GetUserAsync(user);
            return await AddOrder(model, applicationUser);

        }


        /// <summary>
        /// Adds a new order to the database
        /// </summary>
        /// <param name="model"></param>
        /// <param name="buyer"></param>
        /// <returns></returns>
        public async Task<OrderViewModel> AddOrder(OrderBinding model, ApplicationUser buyer)
        {
            var dbo = _mapper.Map<Order>(model);
            dbo.OrderItems = new List<OrderItem>();

            var productItems = _dbo.Products.Where(y => model.OrderItems.Select(x => x.ProductId).Contains(y.Id)).ToList();

            foreach (var product in model.OrderItems)
            {

                var target = productItems.FirstOrDefault(x => x.Id == product.ProductId);
                dbo.OrderItems.Add(new OrderItem
                {
                    ProductId = product.ProductId,
                    Quantity = product.Quantity,
                    Price = target != null ? target.Price : 0
                });

            }

            dbo.OrderStatus = OrderStatus.Pending;
            dbo.Buyer = buyer;
            dbo.CalculateTotal();

            _dbo.Orders.Add(dbo);
            await _dbo.SaveChangesAsync();
            return _mapper.Map<OrderViewModel>(dbo);
        }
        /// <summary>
        /// Gets orders based on user role
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<OrderViewModel>> GetOrders(ClaimsPrincipal user)
        {
            var applicationUser = await _userManager.GetUserAsync(user);
            var role = await _userManager.GetRolesAsync(applicationUser);

            switch (role[0])
            {
                case Roles.Admin:
                    return await GetOrders();
                case Roles.Buyer:
                    return await GetOrders(applicationUser);
                default:
                    throw new NotImplementedException("Role not implemented");
            }

        }
        /// <summary>
        /// Gets all orders from the database
        /// </summary>
        /// <returns></returns>
        public async Task<List<OrderViewModel>> GetOrders()
        {
            var dbo = await _dbo.Orders
                .Include(y => y.Buyer)
                .Include(y => y.OrderItems)
                .Include(y => y.OrderAddress)
                .ToListAsync();

            return _mapper.Map<List<OrderViewModel>>(dbo);
        }
        /// <summary>
        /// gets all orders for a specific buyer
        /// </summary>
        /// <param name="buyer"></param>
        /// <returns></returns>
        public async Task<List<OrderViewModel>> GetOrders(ApplicationUser buyer)
        {
            var dbo = await _dbo.Orders
                .Include(y => y.Buyer)
                .Include(y => y.OrderItems)
                .Include(y => y.OrderAddress)
                .Where(y => y.BuyerId == buyer.Id)
                .ToListAsync();

            return _mapper.Map<List<OrderViewModel>>(dbo);
        }

        /// <summary>
        /// Retrieves an order by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the order to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an  OrderViewModel representing
        /// the order details, or null  if no order with the specified identifier is found.</returns>
        public async Task<OrderViewModel> GetOrder(long id)
        {
            var dbo = await _dbo.Orders
                .Include(y => y.Buyer)
                .Include(y => y.OrderItems)
                .Include(y => y.OrderAddress)
                .FirstOrDefaultAsync(y=>y.Id == id);


            return _mapper.Map<OrderViewModel>(dbo);
        }




    }
}
