using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebShop_Api.Model.Dbo;
using WebShop_Api.Services.Interfaces;
using WebShop_Shared.Model.Binding.ProductModels;
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



        /// <summary>
        /// Adds a new product to the database.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ProductViewModel> Add(ProductBinding model)
        {
            var dbo = _mapper.Map<Product>(model);
            _context.Products.Add(dbo);
            dbo.Created = DateTime.UtcNow;
            dbo.Valid = true;
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductViewModel>(dbo);
        }

        /// <summary>
        /// Updates an existing product.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ProductViewModel?> Update(ProductUpdateBinding model)
        {
            var dbo = await _context.Products.FirstOrDefaultAsync(p => p.Id == model.Id);
            if (dbo == null)
                return null;

            _mapper.Map(model, dbo);
            dbo.Updated = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductViewModel>(dbo);
        }


        /// <summary>
        /// Deletes a product by setting its Valid property to false. 
        /// soft delete.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ProductViewModel> Delete(long id)
        {
            var dbo = await _context.Products
                .Include(p => p.ProductCategory)
                .FirstOrDefaultAsync(p => p.Id == id);
            dbo!.Valid = false;
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductViewModel>(dbo);
        }

    }
}
