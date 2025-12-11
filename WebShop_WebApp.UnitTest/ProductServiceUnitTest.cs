using WebShop_Shared.Model.Binding.ProductModels;
using WebShop_WebApp.Services.Interfaces;

namespace WebShop_WebApp.UnitTest
{
    public class ProductServiceUnitTest : WebShopSetup
    {
        private readonly IProductService productService;
        public ProductServiceUnitTest()
        {
            this.productService = GetProductService();
        }

        [Fact]
        public async void UpdateProduct_UpdatesExistingEntityInDatabase_ReturnsViewModel()
        {
            // Arrange
            var productCategory = new ProductCategoryBinding
            {
                Name = "Electronics",
                Description = "Category for electronic products"
            };
            var productCategoryDbo = await productService.AddProductCategory(productCategory);
            var model = new ProductBinding
            {
                Name = "Laptop",
                Description = "A high-performance laptop",
                Price = 1200.00m,
                ProductCategoryId = productCategoryDbo.Id,
                QuantityTypeId = QuantityTypes[0].Id,
                Quantity = 5
            };
            var addedProduct = await productService.Add(model);
            var updateModel = new ProductUpdateBinding
            {
                Id = addedProduct.Id,
                Name = "Updated Laptop",
                Description = "An updated high-performance laptop",
                Price = 1100.00m,
                QuantityTypeId = QuantityTypes[0].Id,
                Quantity = 7
            };
            // Act
            var result = await productService.Update(updateModel);
            // Assert
            Assert.NotNull(result);
            Assert.Equal(updateModel.Name, result.Name);
            Assert.Equal(updateModel.Description, result.Description);
            Assert.Equal(updateModel.Price, result.Price);
            Assert.Equal(updateModel.QuantityTypeId, result.QuantityType.Id);
        }


        [Fact]
        public async void GetByIdProduct_ReturnsViewModel()
        {
            // Arrange
            var productCategory = new ProductCategoryBinding
            {
                Name = "Electronics",
                Description = "Category for electronic products"
            };
            var productCategoryDbo = await productService.AddProductCategory(productCategory);
            var model = new ProductBinding
            {
                Name = "Laptop",
                Description = "A high-performance laptop",
                Price = 1200.00m,
                ProductCategoryId = productCategoryDbo.Id,
                QuantityTypeId = QuantityTypes[0].Id,
                Quantity = 5
            };
            var addedProduct =  await productService.Add(model);
            // Act
            var result = await productService.GetById(addedProduct.Id);
            // Assert
            Assert.NotNull(result);
            Assert.Equal(addedProduct.Id, result.Id);
            Assert.Equal(addedProduct.Name, result.Name);
            Assert.Equal(addedProduct.Description, result.Description);
            Assert.Equal(addedProduct.Price, result.Price);
            Assert.Equal(addedProduct.ProductCategory.Id, result.ProductCategory.Id);
            Assert.Equal(addedProduct.QuantityType.Id, result.QuantityType.Id);
        }

        [Fact]
        public async void DeleteProduct_DeletesEntityFromDatabase_ReturnsTrue()
        {
            // Arrange
            var productCategory = new ProductCategoryBinding
            {
                Name = "Electronics",
                Description = "Category for electronic products"
            };
            var productCategoryDbo = await productService.AddProductCategory(productCategory);
            var model = new ProductBinding
            {
                Name = "Laptop",
                Description = "A high-performance laptop",
                Price = 1200.00m,
                ProductCategoryId = productCategoryDbo.Id,
                QuantityTypeId = QuantityTypes[0].Id,
                Quantity = 5
            };
            var addedProduct = await productService.Add(model);
            // Act
            var result = await productService.Delete(addedProduct.Id);
            // Assert
            Assert.False(result.Valid);
        }

        [Fact]
        public async void GetAllProducts_ReturnsListOfViewModels()
        {
            // Arrange
            var productCategory = new ProductCategoryBinding
            {
                Name = "Electronics",
                Description = "Category for electronic products"
            };
            var productCategoryDbo = await productService.AddProductCategory(productCategory);
            var model1 = new ProductBinding
            {
                Name = "Laptop",
                Description = "A high-performance laptop",
                Price = 1200.00m,
                ProductCategoryId = productCategoryDbo.Id,
                QuantityTypeId = QuantityTypes[0].Id,
                Quantity = 5
            };
            var model2 = new ProductBinding
            {
                Name = "Smartphone",
                Description = "A latest model smartphone",
                Price = 800.00m,
                ProductCategoryId = productCategoryDbo.Id,
                QuantityTypeId = QuantityTypes[0].Id,
                Quantity = 10
            };
            await productService.Add(model1);
            await productService.Add(model2);
            // Act
            var result = await productService.GetAll();
            // Assert
            Assert.NotNull(result);
            Assert.True(result.Count >= 2);
        }


        [Fact]
        public async void AddProduct_AddsNewEntityToDatabase_ReturnsViewModel()
        {
            var productCategory = new ProductCategoryBinding
            {
                Name = "Electronics",
                Description = "Category for electronic products"
            };

            // Act
            var productCategoryDbo = await productService.AddProductCategory(productCategory);


            // Arrange
            var model = new ProductBinding
            {
                Name = "Laptop",
                Description = "A high-performance laptop",
                Price = 1200.00m,
                ProductCategoryId = productCategoryDbo.Id,
                QuantityTypeId = QuantityTypes[0].Id,
                Quantity =10
            };
            // Act
            var result = await productService.Add(model);
            // Assert
            Assert.NotNull(result);
            Assert.Equal(model.Name, result.Name);
            Assert.Equal(model.Description, result.Description);
            Assert.Equal(model.Price, result.Price);
            Assert.Equal(model.ProductCategoryId, result.ProductCategory.Id);
            Assert.Equal(model.QuantityTypeId, result.QuantityType.Id);
            Assert.NotEqual(0, result.Id);
            Assert.Equal(model.QuantityTypeId, result.QuantityTypeId);
        }



        [Fact]
        public async void AddProductCategory_AddsNewEntityToDatabase_ReturnsViewModel()
        {
            // Arrange
            var model = new ProductCategoryBinding
            {
                Name = "Electronics",
                Description = "Category for electronic products"
            };

            // Act
            var result = await productService.AddProductCategory(model);
            // Assert
            Assert.NotNull(result);
            Assert.Equal(model.Name, result.Name);
            Assert.Equal(model.Description, result.Description);
            Assert.NotEqual(0, result.Id);

        }

        [Fact]
        public async void UpdateProductCategory_UpdatesExistingEntityInDatabase_ReturnsViewModel()
        {
            // Arrange
            var model = new ProductCategoryBinding
            {
                Name = "Electronics",
                Description = "Category for electronic products"
            };
            var addedCategory = await productService.AddProductCategory(model);
            var updateModel = new ProductCategoryUpdateBinding
            {
                Name = "Updated Electronics",
                Description = "Updated description",
                Id = addedCategory.Id
            };
            // Act
            var result = await productService.UpdateProductCategory(updateModel);
            // Assert
            Assert.NotNull(result);
            Assert.Equal(updateModel.Name, result.Name);
            Assert.Equal(updateModel.Description, result.Description);
            Assert.Equal(addedCategory.Id, result.Id);
        }


        [Fact]
        public async void DeleteProductCategory_DeletesEntityFromDatabase_ReturnsTrue()
        {
            // Arrange
            var model = new ProductCategoryBinding
            {
                Name = "Electronics",
                Description = "Category for electronic products"
            };
            var addedCategory = await productService.AddProductCategory(model);
            // Act
            var result = await productService.DeleteProductCategory(addedCategory.Id);
            // Assert
            Assert.False(result.Valid);
        }


        [Fact]
        public async void GetAllProductCategories_ReturnsListOfViewModels()
        {
            // Arrange
            var model1 = new ProductCategoryBinding
            {
                Name = "Electronics",
                Description = "Category for electronic products"
            };
            var model2 = new ProductCategoryBinding
            {
                Name = "Books",
                Description = "Category for books"
            };
            await productService.AddProductCategory(model1);
            await productService.AddProductCategory(model2);
            // Act
            var result = await productService.GetAllProductCategorys();
            // Assert
            Assert.NotNull(result);
            Assert.True(result.Count >= 2);
        }

        [Fact]
        public async void GetByIdProductCategory_ReturnsViewModel()
        {
            // Arrange
            var model = new ProductCategoryBinding
            {
                Name = "Electronics",
                Description = "Category for electronic products"
            };
            var addedCategory = await productService.AddProductCategory(model);
            // Act
            var result = await productService.GetByIdProductCategory(addedCategory.Id);
            // Assert
            Assert.NotNull(result);
            Assert.Equal(addedCategory.Id, result.Id);
            Assert.Equal(addedCategory.Name, result.Name);
            Assert.Equal(addedCategory.Description, result.Description);
        }
    }
}
