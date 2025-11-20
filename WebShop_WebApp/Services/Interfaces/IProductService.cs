using WebShop_Shared.Model.Binding;
using WebShop_Shared.Model.ViewModel;

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
    }
}