using WebShop_Shared.Model.Binding.AccountModels;
using WebShop_Shared.Model.ViewModel.AccountModels;

namespace JwtBearer_Primjer.Services.Interfaces
{
    public interface IAccountService
    {
        Task<TokenViewModel> GetToken(LoginBinding model);
        /// <summary>
        /// Refreshes an expired access token using a refresh token.
        /// </summary>
        /// <param name="tokenModel">The token model binding containing the expired access token and refresh token.</param>
        /// <returns>
        /// A Task resulting in a <see cref="TokenViewModel"/> containing the new access token and refresh token.
        /// </returns>
        /// <exception cref="Exception">Thrown when the provided tokens are invalid or the refresh token has expired.</exception>
        /// <remarks>
        /// This method validates the provided refresh token against the stored token and its expiry time for the associated user. If the validation is successful, it generates a new access token and refresh token for the user. The new refresh token replaces the old one in the user's record. The method returns the new tokens in a TokenViewModel. If the tokens are invalid or the refresh token has expired, an exception is thrown.
        /// </remarks>
        Task<TokenViewModel> RefreshToken(TokenModelBinding tokenModel);
    }
}