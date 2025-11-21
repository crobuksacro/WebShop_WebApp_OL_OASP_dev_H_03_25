using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebShop_Shared.Model.Binding;
using WebShop_Shared.Model.ViewModel;
using WebShop_WebApp.Data;
using WebShop_WebApp.Models.Dbo;
using WebShop_WebApp.Services.Interfaces;

namespace WebShop_WebApp.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProductService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductViewModel>(dbo);
        }


        /// <summary>
        /// Gets all products from the database.
        /// </summary>
        /// <returns></returns>
        public async Task<List<ProductViewModel>> GetAll(bool? valid = null)
        {

            if (!valid.HasValue)
            {
                valid = true;
            }

            var products = await _context.Products
                .Where(p => p.Valid == valid)
                .ToListAsync();
            return _mapper.Map<List<ProductViewModel>>(products);
        }
        /// <summary>
        /// Gets a product by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ProductViewModel?> GetById(long id)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                return null;
            }

            var result = _mapper.Map<ProductViewModel>(product);
            result.QuantityTypes = await GetAllQuantityTypes();

            return result;

        }

        /// <summary>
        /// Updates an existing product.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ProductViewModel?> Update(ProductUpdateBinding model)
        {
            var dbo = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == model.Id);
            if (dbo == null)
            {
                return null;
            }

            _mapper.Map(model, dbo);
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

        /// <summary>
        /// Adds a new ProductCategory to the database.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ProductCategoryViewModel> AddProductCategory(ProductCategoryBinding model)
        {
            var dbo = _mapper.Map<ProductCategory>(model);
            _context.ProductCategorys.Add(dbo);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductCategoryViewModel>(dbo);
        }


        /// <summary>
        /// Gets all ProductCategorys from the database.
        /// </summary>
        /// <returns></returns>
        public async Task<List<ProductCategoryViewModel>> GetAllProductCategorys(bool? valid = null)
        {

            if (!valid.HasValue)
            {
                valid = true;
            }

            var ProductCategorys = await _context.ProductCategorys
                .Where(p => p.Valid == valid)
                .ToListAsync();
            return _mapper.Map<List<ProductCategoryViewModel>>(ProductCategorys);
        }
        /// <summary>
        /// Gets a ProductCategory by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ProductCategoryViewModel?> GetByIdProductCategory(long id)
        {
            var ProductCategory = await _context.ProductCategorys
                .Include(y => y.Products.Where(y => y.Valid))
                .ThenInclude(z => z.QuantityType)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (ProductCategory == null)
            {
                return null;
            }
            return _mapper.Map<ProductCategoryViewModel>(ProductCategory);

        }

        /// <summary>
        /// Updates an existing ProductCategory.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ProductCategoryViewModel?> UpdateProductCategory(ProductCategoryUpdateBinding model)
        {
            var dbo = await _context.ProductCategorys
                .FirstOrDefaultAsync(p => p.Id == model.Id);
            if (dbo == null)
            {
                return null;
            }

            _mapper.Map(model, dbo);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductCategoryViewModel>(dbo);

        }

        /// <summary>
        /// Deletes a ProductCategory by setting its Valid property to false. 
        /// soft delete.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ProductCategoryViewModel> DeleteProductCategory(long id)
        {
            var dbo = await _context.ProductCategorys
                .FirstOrDefaultAsync(p => p.Id == id);
            dbo!.Valid = false;
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductCategoryViewModel>(dbo);
        }

        /// <summary>
        /// Gets all quantity types from the database.
        /// </summary>
        /// <param name="valid"></param>
        /// <returns></returns>
        public async Task<List<QuantityTypeViewModel>> GetAllQuantityTypes(bool? valid = null)
        {
            if (!valid.HasValue)
            {
                valid = true;
            }
            var quantityTypes = await _context.QuantityTypes
                .Where(p => p.Valid == valid)
                .ToListAsync();
            return _mapper.Map<List<QuantityTypeViewModel>>(quantityTypes);
        }
    }
}
