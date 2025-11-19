using WebShop_Shared.Model.Base;

namespace WebShop_Shared.Model.Binding
{
    public class ProductBinding : ProductBase
    {
    }

    public class ProductUpdateBinding : ProductBase
    {
        public long Id { get; set; }
    }

}
