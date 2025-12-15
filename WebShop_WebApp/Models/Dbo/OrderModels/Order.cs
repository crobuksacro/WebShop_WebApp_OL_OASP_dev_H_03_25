using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebShop_Shared.Model.Base.OrderModels;
using WebShop_Shared.Model.Dto;
using WebShop_Shared.Model.Interfaces;

namespace WebShop_WebApp.Models.Dbo.OrderModels
{
    public class Order : OrderBase, IBaseTableAtributes
    {
        [Key]
        public long Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public bool Valid { get; set; }
        [Required(ErrorMessage = "Total price is required.")]
        [Column(TypeName = "decimal(7, 2)")]
        public decimal Total { get; set; }
        public ApplicationUser? Buyer { get; set; }
        public string? BuyerId { get; set; }
        public Address? OrderAddress { get; set; }
        public long? OrderAddressId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public WebShop_WebApp.Models.Dbo.Document.Document? Invoice { get; set; }
        public long? InvoiceId { get; set; }


        public ICollection<OrderItem>? OrderItems { get; set; }


        public void CalculateTotal()
        {
            if (OrderItems == null || !OrderItems.Any())
            {
                Total = 0;
                return;
            }
            Total = OrderItems.Select(y=> y.CaclulateTotalPrice()).Sum();
        }
    }
}
