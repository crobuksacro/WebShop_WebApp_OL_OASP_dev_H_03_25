using WebShop_Shared.Model.Binding.Common;
using WebShop_Shared.Model.Binding.OrderModels;
using WebShop_Shared.Model.Binding.ProductModels;
using WebShop_Shared.Model.Dto;
using WebShop_WebApp.Services.Interfaces;

namespace WebShop_WebApp.UnitTest
{
    public class OrderServiceUnitTest : WebShopSetup
    {
        private readonly IOrderService orderService;
        public OrderServiceUnitTest()
        {
            this.orderService = GetOrderService();
        }


        [Fact]
        public async Task AddOrder_AddsOrderToDb_ReturnsAddedOrderAsViewModel()
        {

            var products = InMemoryDbContext.Products.ToList();


            var orderBinding = new OrderBinding
            {
                Message = "Please deliver between 9 AM and 5 PM.",
                OrderItems = new List<OrderItemBinding>
                {
                    new OrderItemBinding
                    {
                        ProductId = products[1].Id,
                        Quantity = 2
                    },
                    new OrderItemBinding
                    {
                        ProductId = products[0].Id,
                        Quantity = 1
                        
                    }
                },
                OrderAddress = new AddressBinding
                {

                    Street = "123 Main St",
                    City = "Anytown",
                    Country = "USA",
                    Number = "456B"
                }

            };



            var result = await orderService.AddOrder(orderBinding, Buyer);


            Assert.NotNull(result);
            Assert.Equal(OrderStatus.Pending, result.OrderStatus);
        }

    }
}
