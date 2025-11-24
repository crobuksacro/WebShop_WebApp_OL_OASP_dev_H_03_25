using WebShop_Shared.Model.Base.ProductModels;

namespace WebShop_Shared.Model.Binding
{
    public class ProductCategoryBinding : ProductCategoryBase
    {
    }

    public class ProductCategoryUpdateBinding : ProductCategoryBase
    {
        public long Id { get; set; }
    }

}
