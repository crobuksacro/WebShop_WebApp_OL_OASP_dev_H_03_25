using System.Security.Claims;
using WebShop_Shared.Model.Binding.OrderModels;
using WebShop_Shared.Model.ViewModel.OrderModels;
using WebShop_WebApp.Models.Dbo;

namespace WebShop_WebApp.Services.Interfaces
{
    public interface IOrderService
    {
        /// <summary>
        /// Adds a new order to the database
        /// </summary>
        /// <param name="model"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<OrderViewModel> AddOrder(OrderBinding model, ClaimsPrincipal user);
        /// <summary>
        /// Updates the status of an existing order
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<OrderViewModel> UpdateOrderStatus(OrderStatusUpdateBinding model);
        /// <summary>
        /// Adds a new order to the database
        /// </summary>
        /// <param name="model"></param>
        /// <param name="buyer"></param>
        /// <returns></returns>
        Task<OrderViewModel> AddOrder(OrderBinding model, ApplicationUser buyer);
        /// <summary>
        /// Gets orders based on user role
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        Task<List<OrderViewModel>> GetOrders(ClaimsPrincipal user);

        /// <summary>
        /// Gets all orders from the database
        /// </summary>
        /// <returns></returns>
        Task<List<OrderViewModel>> GetOrders();


        /// <summary>
        /// gets all orders for a specific buyer
        /// </summary>
        /// <param name="buyer"></param>
        /// <returns></returns>
        Task<List<OrderViewModel>> GetOrders(ApplicationUser buyer);
        /// <summary>
        /// Retrieves an order by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the order to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an  OrderViewModel representing
        /// the order details, or null  if no order with the specified identifier is found.</returns>
        Task<OrderViewModel> GetOrder(long id);
    }
}