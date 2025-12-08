using WebShop_Shared.Model.Base.OrderModels;

namespace WebShop_Shared.Model.ViewModel.OrderModels
{
    public class OrderItemViewModel : OrderItemBase
    {
        public long Id { get; set; }
        public long? ProductId { get; set; }
    }
}
