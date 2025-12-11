using Microsoft.AspNetCore.Identity;

namespace WebShop_WebApp.Models.Dbo
{
    public class ApplicationUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public Address? Address { get; set; }
    }
}
