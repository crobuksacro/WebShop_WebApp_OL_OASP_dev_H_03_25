using WebShop_Shared.Model.Base.ProductModels;

namespace WebShop_Shared.Model.ViewModel.ProductModels
{
    public class ProductViewModel : ProductBase
    {
        public long Id { get; set; }
        public long? ProductCategoryId { get; set; }
        public ProductCategoryViewModel? ProductCategory { get; set; }

        public long? QuantityTypeId { get; set; }
        public QuantityTypeViewModel? QuantityType { get; set; }


        /// <summary>
        /// Ako nudimo mogučnost odabira, onda koristimo ovaj popis
        /// </summary>
        public List<QuantityTypeViewModel> QuantityTypes { get; set; }
        public bool Valid { get; set; }
    }
}
