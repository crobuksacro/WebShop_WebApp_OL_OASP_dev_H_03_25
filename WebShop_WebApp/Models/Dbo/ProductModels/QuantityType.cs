using WebShop_Shared.Model.Base.ProductModels;
using WebShop_Shared.Model.Interfaces;

namespace WebShop_WebApp.Models.Dbo.ProductModels
{
    public class QuantityType: QuantityTypeBase, IBaseTableAtributes
    {
        public long Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public bool Valid { get; set; }
    
    }
}
