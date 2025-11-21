using WebShop_Shared.Model.Base;
using WebShop_Shared.Model.ViewModel;

namespace WebShop_Shared.Model.Binding
{
    public class ProductBinding : ProductBase
    {
        public long ProductCategoryId { get; set; }
        public long? QuantityTypeId { get; set; }
        public List<QuantityTypeViewModel>? QuantityTypes { get; set; }
    }

    public class ProductUpdateBinding : ProductBase
    {
        public long Id { get; set; }
        public long? QuantityTypeId { get; set; }
    }

}
