using System.ComponentModel;

namespace WebShop_Shared.Model.Base.ProductModels
{
    public abstract class QuantityTypeBase
    {
        [DisplayName("Tip Količine")]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
