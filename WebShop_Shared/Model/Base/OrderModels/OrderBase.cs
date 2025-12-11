using System.ComponentModel.DataAnnotations;

namespace WebShop_Shared.Model.Base.OrderModels
{
    public abstract class OrderBase
    {
        [Display(Name = "Poruka")]
        public string? Message { get; set; }

    }
}
