using System.ComponentModel;

namespace WebShop_Shared.Model.Base.ProductModels
{
    public abstract class ProductBase
    {
        [DisplayName("Naziv")]
        public string Name { get; set; }
        [DisplayName("Opis")]
        public string? Description { get; set; }
        [DisplayName("Cijena")]
        public decimal Price { get; set; }
        [DisplayName("Količina")]
        public decimal? Quantity { get; set; }
    }
}
