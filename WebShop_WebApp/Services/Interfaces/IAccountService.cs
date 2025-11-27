using WebShop_Shared.Model.Binding.AccountModels;
using WebShop_Shared.Model.ViewModel.UserModel;

namespace WebShop_WebApp.Services.Interfaces
{
    public interface IAccountService
    {
        Task<ApplicationUserViewModel> CreateUser(RegistrationBinding model, string role);
    }
}