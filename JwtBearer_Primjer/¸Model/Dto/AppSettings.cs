namespace JwtBearer_Primjer._Model.Dto
{
    public class AppSettings
    {
        public Jwt Jwt { get; set; }
        public int TokenValidityInMinutes { get; set; }
    }

    public class Jwt
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string Key { get; set; }
    }
}
