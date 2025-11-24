using Microsoft.AspNetCore.Identity;
using WebShop_Shared.Model.Dto;
using WebShop_WebApp.Models.Dbo;
using WebShop_WebApp.Services.Interfaces;

namespace WebShop_WebApp.Services.Implementations
{
    public class IdentitySetup : IIdentitySetup
    {
        private RoleManager<IdentityRole> roleManager;
        private UserManager<ApplicationUser> userManager;

        public IdentitySetup(IServiceScopeFactory scopeFactory)
        {
            using (var scope = scopeFactory.CreateScope())
            {
                roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                CreateRoleAsync(Roles.Admin).Wait();
                CreateRoleAsync(Roles.Buyer).Wait();
                CreatePlatformAdminAsync().Wait();

            }
        }

        public async Task CreatePlatformAdminAsync()
        {
            string adminEmail = "webshopadmin@gmail.com";
            var find = await userManager.FindByEmailAsync(adminEmail);
            if (find != null)
            {
                return;
            }

            var adminUser = new ApplicationUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                FirstName = "WebShop",
                LastName = "Admin",
                RegistrationDate = DateTime.Now,
                EmailConfirmed = true
            };
            var result = await userManager.CreateAsync(adminUser, "Admin@123?");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, Roles.Admin);
            }


        }

        public async Task CreateRoleAsync(string role)
        {
            var roleExist = await roleManager.RoleExistsAsync(role);
            if (!roleExist)
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

    }
}
