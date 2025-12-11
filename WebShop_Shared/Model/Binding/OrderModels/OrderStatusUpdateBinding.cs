using WebShop_Shared.Model.Dto;

namespace WebShop_Shared.Model.Binding.OrderModels
{
    public class OrderStatusUpdateBinding
    {
        public long OrderId { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
