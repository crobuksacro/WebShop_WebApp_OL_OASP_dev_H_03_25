using WebShop_Shared.Model.Base.OrderModels;
using WebShop_Shared.Model.Binding.Common;
using WebShop_Shared.Model.Dto;

namespace WebShop_Shared.Model.Binding.OrderModels
{
    public class OrderUpdateBinding : OrderBase
    {
        public long Id { get; set; }
        public OrderStatus? OrderStatus { get; set; }
        public AddressUpdateBinding? OrderAddress { get; set; }
        public List<OrderItemUpdateBinding>? OrderItems { get; set; }
    }
}
