using WebShop_Shared.Model.Binding.ProductModels;
using WebShop_Shared.Model.ViewModel.ProductModels;

namespace WebShop_Api.Services.Interfaces
{
    public interface IProductService
    {

        /// <summary>
        /// Asynchronously retrieves a list of product view models, optionally filtered by a set of product IDs.
        /// </summary>
        /// <param name="id">An optional list of product IDs to filter the results. If null or empty, all valid products are returned.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of product view models matching
        /// the specified IDs, or all valid products if no IDs are provided.</returns>
        Task<List<ProductViewModel>> GetAll(List<long>? id = null);
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
        /// Updates an existing product.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ProductViewModel?> Update(ProductUpdateBinding model);
    }
}