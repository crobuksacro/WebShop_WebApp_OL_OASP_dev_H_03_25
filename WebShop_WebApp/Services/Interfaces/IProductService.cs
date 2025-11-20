using Microsoft.EntityFrameworkCore;
using WebShop_Shared.Model.Binding;
using WebShop_Shared.Model.ViewModel;
using WebShop_WebApp.Models.Dbo;

namespace WebShop_WebApp.Services.Interfaces
{
    public interface IProductService
    {
        /// <summary>
        /// Adds a new product to the database.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ProductViewModel> Add(ProductBinding model);
        /// <summary>
        /// Deletes a product by setting its Valid property to false. 
        /// soft delete.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ProductViewModel> Delete(long id);
        /// <summary>
        /// Gets all products from the database.
        /// </summary>
        /// <returns></returns>
        Task<List<ProductViewModel>> GetAll(bool? valid = null);
        /// <summary>
        /// Gets a product by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ProductViewModel?> GetById(long id);
        /// <summary>
        /// Updates an existing product.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ProductViewModel?> Update(ProductUpdateBinding model);
        /// <summary>
        /// Adds a new ProductCategory to the database.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
         Task<ProductCategoryViewModel> AddProductCategory(ProductCategoryBinding model);
        /// <summary>
        /// Gets all ProductCategorys from the database.
        /// </summary>
        /// <returns></returns>
        Task<List<ProductCategoryViewModel>> GetAllProductCategorys(bool? valid = null);
        /// <summary>
        /// Gets a ProductCategory by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ProductCategoryViewModel?> GetByIdProductCategory(long id);

        /// <summary>
        /// Updates an existing ProductCategory.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ProductCategoryViewModel?> UpdateProductCategory(ProductCategoryUpdateBinding model);

        /// <summary>
        /// Deletes a ProductCategory by setting its Valid property to false. 
        /// soft delete.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ProductCategoryViewModel> DeleteProductCategory(long id);
    }
}