using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using Moq;
using WebShop_WebApp.Data;
using WebShop_WebApp.Mapping;
using WebShop_WebApp.Models.Dbo;
using WebShop_WebApp.Services.Implementations;
using WebShop_WebApp.Services.Interfaces;

namespace WebShop_WebApp.UnitTest
{
    public abstract class WebShopSetup
    {
        protected IMapper Mapper { get; private set; }
        protected ApplicationDbContext InMemoryDbContext;
        protected readonly Mock<UserManager<ApplicationUser>> UserManager;



        public WebShopSetup()
        {
            SetupInMemoryContext();
            var userStoreMock = Mock.Of<IUserStore<ApplicationUser>>();
            UserManager = new Mock<UserManager<ApplicationUser>>(userStoreMock, null, null, null, null, null, null, null, null);
            var loggerFactory = LoggerFactory.Create(builder => { });

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            }, loggerFactory);

            Mapper = configuration.CreateMapper();

        }


        protected IProductService GetProductService(ApplicationDbContext? db = null)
        {
            if(db != null)
            {
                return new ProductService(db, Mapper);
            }
            return new ProductService(InMemoryDbContext, Mapper);
        }

        private void SetupInMemoryContext()
        {
            var inMemoryOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                            .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                            .Options;
            InMemoryDbContext = new ApplicationDbContext(inMemoryOptions);
        }
    }
}