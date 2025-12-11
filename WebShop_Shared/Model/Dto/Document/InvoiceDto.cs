using WebShop_Shared.Model.ViewModel.OrderModels;
using WebShop_Shared.Model.ViewModel.UserModel;

namespace WebShop_Shared.Model.Dto.Document
{
    public class InvoiceDto 
    {
        public OrderViewModel Order { get; set; }
        public PaymentMethod PaymentMethod { get; set; }


        public string BuyerId { get; set; }

    }
}
