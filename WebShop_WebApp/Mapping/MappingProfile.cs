using AutoMapper;
using WebShop_Shared.Model.Binding;
using WebShop_Shared.Model.ViewModel;
using WebShop_Shared.Model.ViewModel.UserModel;
using WebShop_WebApp.Models.Dbo;
using WebShop_WebApp.Models.Dbo.ProductModels;

namespace WebShop_WebApp.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductUpdateBinding, Product>();
            CreateMap<ProductBinding, Product>();
            CreateMap<ProductCategory, ProductCategoryViewModel>();
            CreateMap<ProductCategoryUpdateBinding, ProductCategory>();
            CreateMap<ProductCategoryBinding, ProductCategory>();

            CreateMap<QuantityType, QuantityTypeViewModel>();
            CreateMap<ApplicationUser, ApplicationUserViewModel>();
        }
    }
}
