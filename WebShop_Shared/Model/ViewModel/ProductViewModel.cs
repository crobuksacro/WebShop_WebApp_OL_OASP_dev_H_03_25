using WebShop_Shared.Model.Base;

namespace WebShop_Shared.Model.ViewModel
{
    public class ProductViewModel: ProductBase
    {
        public long Id { get; set; }
        public long? ProductCategoryId { get; set; }
    }
}
