using System.ComponentModel.DataAnnotations;
using WebShop_Shared.Model.Base.OrderModels;
using WebShop_Shared.Model.Interfaces;
using WebShop_WebApp.Models.Dbo.ProductModels;

namespace WebShop_WebApp.Models.Dbo.OrderModels
{
    public class OrderItem : OrderItemBase, IBaseTableAtributes
    {
        [Key]
        public long Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public bool Valid { get; set; }
        public Product? Product { get; set; }
        public long? ProductId { get; set; }


        public decimal CaclulateTotalPrice()
        {
            return Price * Quantity;
        }

    }
}
