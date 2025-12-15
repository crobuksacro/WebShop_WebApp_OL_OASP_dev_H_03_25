using Ispit.Books.Models.Dbo;
using Ispit.Books.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using WebShop_Shared.Model.Dto;

namespace Ispit.Books.Services.Implementations
{
    public class IdentitySetup : IIdentitySetup
    {
        private RoleManager<IdentityRole> roleManager;
        private UserManager<AspNetUser> userManager;

        public IdentitySetup(IServiceScopeFactory scopeFactory)
        {
            using (var scope = scopeFactory.CreateScope())
            {
                roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                userManager = scope.ServiceProvider.GetRequiredService<UserManager<AspNetUser>>();

                CreateRoleAsync(Roles.Admin).Wait();
                CreatePlatformAdminAsync().Wait();

            }
        }

        public async Task CreatePlatformAdminAsync()
        {
            string adminEmail = "admin@admin.com";
            var find = await userManager.FindByEmailAsync(adminEmail);
            if (find != null)
            {
                return;
            }

            var adminUser = new AspNetUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                FirstName = "WebShop",
                LastName = "Admin",
                EmailConfirmed = true
            };
            var result = await userManager.CreateAsync(adminUser, "Password12345");
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
