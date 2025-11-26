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
        public async void UpgradeProductCategory_UpdatesExistingEntityInDatabase_ReturnsViewModel()
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
