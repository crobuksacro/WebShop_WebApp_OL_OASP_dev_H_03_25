using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebShop_Api.Model.Dbo;
using WebShop_Api.Services.Interfaces;
using WebShop_Shared.Model.ViewModel.ProductModels;

namespace WebShop_Api.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly AspnetWebShopWebAppContext _context;
        private readonly IMapper _mapper;

        public ProductService(AspnetWebShopWebAppContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Asynchronously retrieves a list of product view models, optionally filtered by a set of product IDs.
        /// </summary>
        /// <param name="id">An optional list of product IDs to filter the results. If null or empty, all valid products are returned.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of product view models matching
        /// the specified IDs, or all valid products if no IDs are provided.</returns>
        public async Task<List<ProductViewModel>> GetAll(List<long>? id = null)
        {

            var dbo = new List<Product>();

            if (id == null || !id.Any())
            {
                dbo = await _context.Products.Where(p => p.Valid).ToListAsync();
            }
            else
            {
                dbo = await _context.Products.Where(p => id.Contains(p.Id)).ToListAsync();
            }

            return _mapper.Map<List<ProductViewModel>>(dbo);
        }

    }
}
