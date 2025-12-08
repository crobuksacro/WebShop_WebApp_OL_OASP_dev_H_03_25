using AutoMapper;
using WebShop_Shared.Model.Binding.Common;
using WebShop_Shared.Model.Binding.OrderModels;
using WebShop_Shared.Model.Binding.ProductModels;
using WebShop_Shared.Model.ViewModel.Common;
using WebShop_Shared.Model.ViewModel.OrderModels;
using WebShop_Shared.Model.ViewModel.ProductModels;
using WebShop_Shared.Model.ViewModel.UserModel;
using WebShop_WebApp.Models.Dbo;
using WebShop_WebApp.Models.Dbo.OrderModels;
using WebShop_WebApp.Models.Dbo.ProductModels;

namespace WebShop_WebApp.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderBinding, Order>()
                .ForMember(dest => dest.OrderItems, opt => opt.Ignore());

            CreateMap<OrderUpdateBinding, Order>();

            CreateMap<Order, OrderViewModel>();
            CreateMap<OrderItem, OrderItemViewModel>();
            CreateMap<OrderItemViewModel, OrderItemUpdateBinding>();
            CreateMap<OrderViewModel, OrderUpdateBinding>();

            CreateMap<OrderItemUpdateBinding, OrderItem>();

            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductUpdateBinding, Product>();
            CreateMap<ProductBinding, Product>();
            CreateMap<ProductCategory, ProductCategoryViewModel>();
            CreateMap<ProductCategoryUpdateBinding, ProductCategory>();
            CreateMap<ProductCategoryBinding, ProductCategory>();

            CreateMap<QuantityType, QuantityTypeViewModel>();
            CreateMap<ApplicationUser, ApplicationUserViewModel>();
            CreateMap<AddressBinding, Address>();
            CreateMap<AddressUpdateBinding, Address>();
            CreateMap<Address, AddressViewModel>();
            CreateMap<Address, AddressBinding>();

            CreateMap<AddressViewModel, AddressUpdateBinding>();





        }
    }
}
