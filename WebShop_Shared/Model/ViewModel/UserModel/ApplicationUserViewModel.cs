using System.ComponentModel.DataAnnotations;
using WebShop_Shared.Model.ViewModel.Common;

namespace WebShop_Shared.Model.ViewModel.UserModel
{
    public class ApplicationUserViewModel
    {
        public string Id { get; set; }
        [Display(Name = "Ime")]
        public string FirstName { get; set; }
        [Display(Name = "Prezime")]
        public string LastName { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public AddressViewModel? Address { get; set; }
    }
}
