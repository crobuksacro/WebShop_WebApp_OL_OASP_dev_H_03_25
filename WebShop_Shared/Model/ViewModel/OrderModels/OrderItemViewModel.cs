using WebShop_Shared.Model.Base.OrderModels;
using WebShop_Shared.Model.ViewModel.ProductModels;

namespace WebShop_Shared.Model.ViewModel.OrderModels
{
    public class OrderItemViewModel : OrderItemBase
    {
        public long Id { get; set; }
        public long? ProductId { get; set; }
        public ProductViewModel? Product { get; set; }
    }
}
