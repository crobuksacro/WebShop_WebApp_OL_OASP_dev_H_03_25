using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebShop_WebApp.Data;
using WebShop_WebApp.Mapping;
using WebShop_WebApp.Models.Dbo;
using WebShop_WebApp.Services.Implementations;
using WebShop_WebApp.Services.Interfaces;

namespace WebShop_WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();


            #region Identity Configuration

                    builder.Services.AddDefaultIdentity<ApplicationUser>(
                 options => {
                     options.SignIn.RequireConfirmedAccount = true;
                     options.Password.RequiredLength = 6;
                     options.Password.RequiredUniqueChars = 0;
                     options.Password.RequireLowercase = false;
                     options.Password.RequireUppercase = false;
                     options.Password.RequireNonAlphanumeric = false;
                     options.Password.RequireDigit = false;
                 }


                 )
                 .AddRoles<IdentityRole>()
                 .AddEntityFrameworkStores<ApplicationDbContext>();

            #endregion

            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IProductService, ProductService>();

            #region AutoMapper Configuration
            var loggerFactory = builder.Services.BuildServiceProvider().GetRequiredService<ILoggerFactory>();
            var configuration = new MapperConfiguration(cfg => {
                cfg.AddProfile<MappingProfile>();
            }, loggerFactory);

            var mapper = configuration.CreateMapper();
            builder.Services.AddSingleton(mapper);
            #endregion



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}
