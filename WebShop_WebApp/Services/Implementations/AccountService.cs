using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebShop_Shared.Model.Binding.AccountModels;
using WebShop_Shared.Model.ViewModel.Common;
using WebShop_Shared.Model.ViewModel.UserModel;
using WebShop_WebApp.Data;
using WebShop_WebApp.Models.Dbo;
using WebShop_WebApp.Services.Interfaces;

namespace WebShop_WebApp.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private UserManager<ApplicationUser> userManager;
        private ApplicationDbContext db;
        private IMapper mapper;
        private SignInManager<ApplicationUser> signInManager;

        public AccountService(UserManager<ApplicationUser> userManager, ApplicationDbContext db,
            IMapper mapper, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.db = db;
            this.mapper = mapper;
            this.signInManager = signInManager;
        }

        /// <summary>
        /// Gets the address of the specified user.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<T> GetUserAddress<T>(ClaimsPrincipal user)
        {
            var applicationUser = await userManager.GetUserAsync(user);
            var dbo = await db.Users
                 .Include(y => y.Address)
                 .FirstOrDefaultAsync(y => y.Id == applicationUser.Id);

            return mapper.Map<T>(dbo.Address);
        }


        /// <summary>
        /// Creates a new user with the specified role.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public async Task<ApplicationUserViewModel> CreateUser(RegistrationBinding model, string role)
        {
            var find = await userManager.FindByEmailAsync(model.Email);
            if (find != null)
            {
                return null;
            }
            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                RegistrationDate = DateTime.Now
            };

            user.EmailConfirmed = true;
            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, role);
                await userManager.UpdateAsync(user);
                await signInManager.SignInAsync(user, false);

                return mapper.Map<ApplicationUserViewModel>(user);

            }

            return null;
        }


    }
}
