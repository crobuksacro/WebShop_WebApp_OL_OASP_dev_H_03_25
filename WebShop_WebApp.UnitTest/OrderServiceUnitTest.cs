using WebShop_Shared.Model.Binding.Common;
using WebShop_Shared.Model.Binding.OrderModels;
using WebShop_Shared.Model.Dto;
using WebShop_Shared.Model.ViewModel.OrderModels;
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
        public async Task UpdateOrder_UpdatessOrderToDb_ReturnsUpdatedOrderAsViewModel()
        {
            OrderViewModel result = await AddOrder();
            var input = Mapper.Map<OrderUpdateBinding>(result);
            input.OrderStatus = OrderStatus.Shipped;

            var newOrderQuantity = result.OrderItems[0].Quantity + 10;

            input.OrderItems[0].Quantity = newOrderQuantity;

            var updatedResult = await orderService.UpdateOrder(input);
            Assert.NotNull(updatedResult);
            Assert.Equal(result.Id, updatedResult.Id);
            Assert.Equal(result.OrderItems.Count, updatedResult.OrderItems.Count);

            Assert.Equal(OrderStatus.Shipped, updatedResult.OrderStatus);
            Assert.Equal(newOrderQuantity, updatedResult.OrderItems[0].Quantity);
        }



        [Fact]
        public async Task AddOrder_AddsOrderToDb_ReturnsAddedOrderAsViewModel()
        {
            OrderViewModel result = await AddOrder();
            Assert.NotNull(result);
            Assert.Equal(OrderStatus.Pending, result.OrderStatus);
        }

        [Fact]
        public async Task GetAllOrders_ReturnsListOfOrders()
        {
            await AddOrder();
            var result = await orderService.GetOrders(Buyer);
            Assert.NotNull(result);
            Assert.IsType<List<OrderViewModel>>(result);
            Assert.Single(result);
            Assert.Equal(OrderStatus.Pending, result[0].OrderStatus);
        }

        [Fact]
        public async Task UpdateOrderStatus_UpdatesOrderStatusToNewStastus_ReturnsOrderViewModel()
        {


            var addedOrder = await AddOrder();
            var orderStatusUpdateBinding = new OrderStatusUpdateBinding
            {
                OrderId = addedOrder.Id,
                OrderStatus = OrderStatus.Shipped
            };
            var result = await orderService.UpdateOrderStatus(orderStatusUpdateBinding);
            Assert.NotNull(result);
            Assert.IsType<OrderViewModel>(result);
            Assert.Equal(OrderStatus.Shipped, result.OrderStatus);
        }


        private async Task<OrderViewModel> AddOrder()
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
            return result;
        }


    }
}
