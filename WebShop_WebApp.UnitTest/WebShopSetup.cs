using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using Moq;
using WebShop_WebApp.Data;
using WebShop_WebApp.Mapping;
using WebShop_WebApp.Models.Dbo;
using WebShop_WebApp.Models.Dbo.ProductModels;
using WebShop_WebApp.Services.Implementations;
using WebShop_WebApp.Services.Interfaces;

namespace WebShop_WebApp.UnitTest
{
    public abstract class WebShopSetup
    {
        protected IMapper Mapper { get; private set; }
        protected ApplicationDbContext InMemoryDbContext;
        protected readonly Mock<UserManager<ApplicationUser>> UserManager;
        protected List<QuantityType> QuantityTypes;
        protected readonly ApplicationUser Buyer;
        protected readonly List<ProductCategory> ProductCategories;


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
            SeedQuantityTypes();
            Buyer = GetApplicationUser();
            ProductCategories = GetProductCategories(20);
        }

        protected void SeedQuantityTypes()
        {
            QuantityTypes = new List<QuantityType>
            {
                new QuantityType { Id = 1, Name = "Piece", Created = DateTime.Now, Description = "A single item", Valid = true },
                new QuantityType { Id = 2, Name = "Kilogram", Created = DateTime.Now, Description = "Weight in kilograms", Valid = true },
                new QuantityType { Id = 3, Name = "Liter", Created = DateTime.Now, Description = "Volume in liters", Valid = true }
            };
            InMemoryDbContext.QuantityTypes.AddRange(QuantityTypes);
            InMemoryDbContext.SaveChanges();
        }


        protected IProductService GetProductService(ApplicationDbContext? db = null)
        {
            if (db != null)
            {
                return new ProductService(db, Mapper);
            }
            return new ProductService(InMemoryDbContext, Mapper);
        }


        protected IOrderService GetOrderService(ApplicationDbContext? db = null)
        {
            if (db != null)
            {
                return new OrderService(db, Mapper, UserManager.Object, GetDocumentService(db));
            }
            return new OrderService(InMemoryDbContext, Mapper, UserManager.Object, GetDocumentService());
        }

        protected IDocumentService GetDocumentService(ApplicationDbContext? db = null)
        {
            if (db != null)
            {
                return new DocumentService(db, Mapper, UserManager.Object);
            }
            return new DocumentService(InMemoryDbContext, Mapper, UserManager.Object);
        }


        private void SetupInMemoryContext()
        {
            var inMemoryOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                            .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                            .Options;
            InMemoryDbContext = new ApplicationDbContext(inMemoryOptions);
        }


        protected ApplicationUser GetApplicationUser()
        {
            var applicationUser = new ApplicationUser
            {
                UserName = "testuser",
                Email = $"{Guid.NewGuid()}@example.com",
                FirstName = "Test",
                LastName = "User",
                PhoneNumber = "1234567890",
                EmailConfirmed = true,
                Address = new Address
                {
                    Street = "123 Test St",
                    Number = "1A",
                    City = "Testville",
                    Country = "Testland"
                },

            };

            InMemoryDbContext.Users.Add(applicationUser);
            InMemoryDbContext.SaveChanges();
            return applicationUser;

        }


        protected List<ProductCategory> GetProductCategories(int? number = null)
        {
            if (!number.HasValue)
            {
                    var productCategories = new List<ProductCategory>
                {
                    new ProductCategory { Name = "Electronics", Description = "Electronic devices and gadgets", Products = GetProducts(false,3) },
                    new ProductCategory { Name = "Books", Description = "Various kinds of books", Products = GetProducts(false, 2) },
                    new ProductCategory { Name = "Clothing", Description = "Apparel and accessories", Products = GetProducts(false, 1) }
                };
                    InMemoryDbContext.ProductCategorys.AddRange(productCategories);
                    InMemoryDbContext.SaveChanges();
                    return productCategories;
            }




            List<ProductCategory> categories = new List<ProductCategory>();
            Random random = new Random();

            for (int i = 0; i < number.Value; i++)
            {
                var category = new ProductCategory
                {
                    Name = $"Category {i + 1}",
                    Description = $"Description for Category {i + 1}",
                    Products = GetProducts(false, random.Next(1, i + 2)),

                };
                categories.Add(category);
            }

            InMemoryDbContext.ProductCategorys.AddRange(categories);
            InMemoryDbContext.SaveChanges();
            return categories;

        }


        public List<Product> GetProducts(bool saveInDb, int number = 1)
        {
            List<Product> products = new List<Product>();
            Random random = new Random();


            for (int i = 0; i < number; i++)
            {
                var product = new Product
                {
                    Name = $"Product {i + 1}",
                    Description = $"Description for Product {i + 1}",
                    Price = 10.0m * (i + 1),
                    QuantityTypeId = QuantityTypes[random.Next(QuantityTypes.Count)].Id,
                    Valid = true,
                    Quantity = 100,
                    Created = DateTime.Now
                };
                products.Add(product);
            }

            if (saveInDb)
            {
                InMemoryDbContext.Products.AddRange(products);
                InMemoryDbContext.SaveChanges();
            }


            return products;

        }


      
    }
}