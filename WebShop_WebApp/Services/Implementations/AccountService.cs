using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebShop_Shared.Model.Binding.AccountModels;
using WebShop_Shared.Model.Binding.Common;
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
        private ApplicationDbContext _context;
        private IMapper _mapper;
        private SignInManager<ApplicationUser> signInManager;

        public AccountService(UserManager<ApplicationUser> userManager, ApplicationDbContext db,
            IMapper mapper, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this._context = db;
            this._mapper = mapper;
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
            var dbo = await _context.Users
                 .Include(y => y.Address)
                 .FirstOrDefaultAsync(y => y.Id == applicationUser.Id);

            return _mapper.Map<T>(dbo.Address);
        }
        /// <summary>
        /// Updates Address
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<AddressViewModel> UpdateAddress(AddressUpdateBinding model)
        {
            var dbo = await _context.Addresss.FindAsync(model.Id);
            _mapper.Map(model, dbo);
            await _context.SaveChangesAsync();
            return _mapper.Map<AddressViewModel>(dbo);

        }
        /// <summary>
        /// Gets Address using id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<AddressViewModel> GetAddress(long id)
        {
            var dbo = await _context.Addresss.FindAsync(id);
            return _mapper.Map<AddressViewModel>(dbo);

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

                return _mapper.Map<ApplicationUserViewModel>(user);

            }

            return null;
        }


    }
}
