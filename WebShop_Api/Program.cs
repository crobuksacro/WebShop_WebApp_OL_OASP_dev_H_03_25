
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebShop_Api.Mapping;
using WebShop_Api.Model.Dbo;
using WebShop_Api.Services.Implementations;
using WebShop_Api.Services.Interfaces;

namespace WebShop_Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<AspnetWebShopWebAppContext>(options =>
                options.UseSqlServer(connectionString));

            #region AutoMapper Configuration
            var loggerFactory = builder.Services.BuildServiceProvider().GetRequiredService<ILoggerFactory>();
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            }, loggerFactory);

            var mapper = configuration.CreateMapper();
            builder.Services.AddSingleton(mapper);
            builder.Services.AddScoped<IProductService, ProductService>();

            #endregion
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
