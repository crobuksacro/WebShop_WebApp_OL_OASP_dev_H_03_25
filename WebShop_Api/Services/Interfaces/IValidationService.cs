namespace WebShop_Api.Services.Interfaces
{
    public interface IValidationService
    {

        /// <summary>
        /// Validates if a product category with the specified ID exists in the database.
        /// </summary>
        /// <param name="productCategoryId"></param>
        /// <returns></returns>
        Task<bool> ProductCategoryExists(long productCategoryId);
        /// <summary>
        /// Determines whether a quantity type with the specified identifier exists in the data store.
        /// </summary>
        /// <param name="quantityTypeId">The unique identifier of the quantity type to check for existence.</param>
        /// <returns>A task that represents the asynchronous operation. The task result is <see langword="true"/> if a quantity
        /// type with the specified identifier exists; otherwise, <see langword="false"/>.</returns>
        Task<bool> QuantityTypeExists(long quantityTypeId);
        /// <summary>
        /// Provides an asynchronous method to check if a product with the specified ID exists in the database.
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<bool> ProductExists(long productId);
    }
}