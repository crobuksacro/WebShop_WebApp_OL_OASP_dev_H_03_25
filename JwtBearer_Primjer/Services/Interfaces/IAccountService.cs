using WebShop_Shared.Model.Binding.AccountModels;
using WebShop_Shared.Model.ViewModel.AccountModels;

namespace JwtBearer_Primjer.Services.Interfaces
{
    public interface IAccountService
    {
        Task<TokenViewModel> GetToken(LoginBinding model);
    }
}