using AutoMapper;
using WebShop_Shared.Model.Binding;
using WebShop_Shared.Model.ViewModel;
using WebShop_WebApp.Models.Dbo;

namespace WebShop_WebApp.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductUpdateBinding, Product>();
            CreateMap<ProductBinding, Product>();
        }
    }
}
