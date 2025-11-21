using System.ComponentModel;

namespace WebShop_Shared.Model.Base
{
    public abstract class QuantityTypeBase
    {
        [DisplayName("Tip Količine")]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
