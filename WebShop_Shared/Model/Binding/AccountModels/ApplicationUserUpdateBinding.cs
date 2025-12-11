using WebShop_Shared.Model.Binding.Common;

namespace WebShop_Shared.Model.Binding.AccountModels
{
    public class ApplicationUserUpdateBinding
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public AddressUpdateBinding? Address { get; set; }

    }
}
