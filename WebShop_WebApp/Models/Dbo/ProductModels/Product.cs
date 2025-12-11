using WebShop_Shared.Model.Base.ProductModels;
using WebShop_Shared.Model.Interfaces;

namespace WebShop_WebApp.Models.Dbo.ProductModels
{
    public class Product:ProductBase,IBaseTableAtributes
    {
        public long Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public bool Valid { get; set; }

        public ProductCategory? ProductCategory { get; set; }
        public long? ProductCategoryId { get; set; }

        public QuantityType? QuantityType { get; set; }
        public long? QuantityTypeId { get; set; }

    }
}
