using System.Text.Json.Serialization;

namespace WebShop_Shared.Model.Base.AccountModels
{
    public abstract class TokenModelBase
    {
        [JsonPropertyName("accessToken")]
        public string? AccessToken { get; set; }
        [JsonPropertyName("refreshToken")]
        public string? RefreshToken { get; set; }
    }
}
