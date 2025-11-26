using WebShop_WebApp.Services.Interfaces;

namespace WebShop_WebApp.UnitTest
{
    public class ProductServiceUnitTest: WebShopSetup
    {
        private readonly IProductService productService;
        public ProductServiceUnitTest()
        {
            this.productService = GetProductService();
        }
        



    }
}
