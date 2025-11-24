using AutoMapper;
using WebShop_Shared.Model.Binding.OrderModels;
using WebShop_Shared.Model.Dto;
using WebShop_Shared.Model.ViewModel.OrderModels;
using WebShop_WebApp.Data;
using WebShop_WebApp.Models.Dbo;
using WebShop_WebApp.Models.Dbo.OrderModels;

namespace WebShop_WebApp.Services.Implementations
{
    public class OrderService
    {
        private readonly ApplicationDbContext _dbo;
        private readonly IMapper _mapper;


        public OrderService(ApplicationDbContext context, IMapper mapper)
        {
            _dbo = context;
            _mapper = mapper;
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
            var productItems = _dbo.Products.Where(y=> model.OrderItems.Select(x=>x.ProductId).Contains(y.Id)).ToList();

            foreach (var product in dbo.OrderItems)
            {
        
                var target = productItems.FirstOrDefault(x => x.Id == product.ProductId);
                if(target != null)
                {
                    target.Quantity -= product.Quantity;
                    product.Price = target.Price;
                }

            }

            dbo.OrderStatus = OrderStatus.Pending;
            dbo.Buyer = buyer;
            dbo.CalculateTotal();

            _dbo.Orders.Add(dbo);
            await  _dbo.SaveChangesAsync();
            return _mapper.Map<OrderViewModel>(dbo);
        }

    }
}
