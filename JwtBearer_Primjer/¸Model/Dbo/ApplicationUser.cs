using Microsoft.AspNetCore.Identity;

namespace JwtBearer_Primjer._Model.Dbo
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string RefreshToken { get; internal set; }
        public DateTime RefreshTokenExpiryTime { get; internal set; }
    }
}
