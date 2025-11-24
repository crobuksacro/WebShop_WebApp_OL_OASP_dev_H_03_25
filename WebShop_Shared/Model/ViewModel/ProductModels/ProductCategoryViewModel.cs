using WebShop_Shared.Model.Base.ProductModels;

namespace WebShop_Shared.Model.ViewModel.ProductModels
{
    public class ProductCategoryViewModel: ProductCategoryBase
    {
        public long Id { get; set; }
        public List<ProductViewModel>? Products { get; set; }
    }
}
