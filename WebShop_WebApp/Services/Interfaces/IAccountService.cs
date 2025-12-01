using System.Security.Claims;
using WebShop_Shared.Model.Binding.AccountModels;
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
    }
}