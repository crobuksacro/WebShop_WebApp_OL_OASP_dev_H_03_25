using Microsoft.EntityFrameworkCore;
using WebShop_Api.Model.Dbo;
using WebShop_Api.Services.Interfaces;

namespace WebShop_Api.Services.Implementations
{
    public class ValidationService : IValidationService
    {
        private readonly AspnetWebShopWebAppContext _context;

        public ValidationService(AspnetWebShopWebAppContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Validates if a product category with the specified ID exists in the database.
        /// </summary>
        /// <param name="productCategoryId"></param>
        /// <returns></returns>
        public async Task<bool> ProductCategoryExists(long productCategoryId)
        {
            return await _context.ProductCategorys.AnyAsync(pc => pc.Id == productCategoryId);

        }
        /// <summary>
        /// Determines whether a quantity type with the specified identifier exists in the data store.
        /// </summary>
        /// <param name="quantityTypeId">The unique identifier of the quantity type to check for existence.</param>
        /// <returns>A task that represents the asynchronous operation. The task result is <see langword="true"/> if a quantity
        /// type with the specified identifier exists; otherwise, <see langword="false"/>.</returns>
        public async Task<bool> QuantityTypeExists(long quantityTypeId)
        {
            return await _context.QuantityTypes.AnyAsync(pc => pc.Id == quantityTypeId);

        }



    }
}
