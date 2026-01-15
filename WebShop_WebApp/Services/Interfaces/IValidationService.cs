namespace WebShop_WebApp.Services.Interfaces
{
    public interface IValidationService
    {
        Task<bool> ProductCategoryExists(long productCategoryId);
        Task<bool> ProductExists(long productId);
        Task<bool> QuantityTypeExists(long quantityTypeId);
    }
}