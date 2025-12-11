using System.ComponentModel.DataAnnotations;

namespace WebShop_Shared.Model.Base
{
    public abstract class AddressBase
    {
        [Display(Name = "Ulica")]
        public string Street { get; set; }
        [Display(Name = "k.Broj")]
        public string Number { get; set; }
        [Display(Name = "Grad")]
        public string City { get; set; }
        [Display(Name = "Država")]
        public string Country { get; set; }
    }
}
