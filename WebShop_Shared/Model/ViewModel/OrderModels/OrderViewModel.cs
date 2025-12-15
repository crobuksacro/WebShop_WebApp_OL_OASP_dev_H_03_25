using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebShop_Shared.Model.Base.OrderModels;
using WebShop_Shared.Model.Dto;
using WebShop_Shared.Model.ViewModel.Common;
using WebShop_Shared.Model.ViewModel.UserModel;



namespace WebShop_Shared.Model.ViewModel.OrderModels
{
    public class OrderViewModel : OrderBase
    {
        [Display(Name = "Id narudžbe")]
        public long Id { get; set; }
        public DateTime Created { get; set; }
        public ApplicationUserViewModel? Buyer { get; set; }
        public AddressViewModel? OrderAddress { get; set; }
        public OrderStatus? OrderStatus { get; set; }
        public List<OrderItemViewModel>? OrderItems { get; set; }
        [Required(ErrorMessage = "Total price is required.")]
        [Column(TypeName = "decimal(7, 2)")]
        [Display(Name = "Ukupno")]
        public decimal Total { get; set; }
        public long? InvoiceId { get; set; }

        public Dictionary<OrderStatus, string> GetStatusLabels()
        {
            var statusLabels = new Dictionary<OrderStatus, string>
                {
                    { WebShop_Shared.Model.Dto.OrderStatus.Pending, "Narudžba je primljena" },
                    { WebShop_Shared.Model.Dto.OrderStatus.Processing, "Narudžba se obrađuje" },
                    { WebShop_Shared.Model.Dto.OrderStatus.Shipped, "Narudžba je poslana" },
                    { WebShop_Shared.Model.Dto.OrderStatus.Delivered, "Narudžba je isporučena" },
                    { WebShop_Shared.Model.Dto.OrderStatus.Canceled, "Narudžba je otkazana" },
                    { WebShop_Shared.Model.Dto.OrderStatus.Returned, "Narudžba je vraćena" },
                    { WebShop_Shared.Model.Dto.OrderStatus.Refunded, "Narudžba je refundirana" }
                };

            return statusLabels;
        }



    }
}
