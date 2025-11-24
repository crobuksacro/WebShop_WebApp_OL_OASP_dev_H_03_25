using System.ComponentModel;

namespace WebShop_Shared.Model.Base.ProductModels
{
    public abstract class ProductCategoryBase
    {
        [DisplayName("Naziv Kategorije")]
        public string Name { get; set; }
        [DisplayName("Opis")]
        public string Description { get; set; }
    }
}
