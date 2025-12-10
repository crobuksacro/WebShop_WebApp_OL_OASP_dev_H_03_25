using System.Security.Claims;
using WebShop_Shared.Model.Binding.AccountModels;
using WebShop_Shared.Model.Binding.Common;
using WebShop_Shared.Model.ViewModel.Common;
using WebShop_Shared.Model.ViewModel.UserModel;

namespace WebShop_WebApp.Services.Interfaces
{
    public interface IAccountService
    {
        Task<ApplicationUserViewModel> CreateUser(RegistrationBinding model, string role);
        /// <summary>
        /// Gets the address of the specified user.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<T> GetUserAddress<T>(ClaimsPrincipal user);
        /// <summary>
        /// Updates Address
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<AddressViewModel> UpdateAddress(AddressUpdateBinding model);
        /// <summary>
        /// Gets Address using id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<AddressViewModel> GetAddress(long id);
    }
}