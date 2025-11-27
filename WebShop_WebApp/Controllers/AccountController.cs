using Microsoft.AspNetCore.Mvc;
using WebShop_Shared.Model.Binding.AccountModels;
using WebShop_Shared.Model.Dto;
using WebShop_WebApp.Services.Interfaces;

namespace WebShop_WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationBinding model)
        {
            await _accountService.CreateUser(model, Roles.Buyer);
            return RedirectToAction("Index","Buyer");
        }
    }
}
