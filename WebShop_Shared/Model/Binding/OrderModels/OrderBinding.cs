using WebShop_Shared.Model.Base.OrderModels;
using WebShop_Shared.Model.Binding.Common;

namespace WebShop_Shared.Model.Binding.OrderModels
{
    public class OrderBinding : OrderBase
    {
        public AddressBinding? OrderAddress { get; set; }
        public List<OrderItemBinding>? OrderItems { get; set; }
    }
}
