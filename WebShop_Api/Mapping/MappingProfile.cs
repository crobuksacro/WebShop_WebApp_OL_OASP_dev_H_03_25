using AutoMapper;
using WebShop_Api.Model.Dbo;
using WebShop_Shared.Model.Binding.AccountModels;
using WebShop_Shared.Model.Binding.Common;
using WebShop_Shared.Model.Binding.OrderModels;
using WebShop_Shared.Model.Binding.ProductModels;
using WebShop_Shared.Model.ViewModel.Common;
using WebShop_Shared.Model.ViewModel.Document;
using WebShop_Shared.Model.ViewModel.OrderModels;
using WebShop_Shared.Model.ViewModel.ProductModels;
using WebShop_Shared.Model.ViewModel.UserModel;

namespace WebShop_Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {


            #region Order
            CreateMap<OrderBinding, Order>()
                .ForMember(dest => dest.OrderItems, opt => opt.Ignore());

            CreateMap<OrderUpdateBinding, Order>().ForMember(dest => dest.OrderItems, opt => opt.Ignore());
            CreateMap<Order, OrderViewModel>();
            CreateMap<OrderItem, OrderItemViewModel>();
            CreateMap<OrderItemViewModel, OrderItemUpdateBinding>();
            CreateMap<OrderViewModel, OrderUpdateBinding>();
            CreateMap<OrderItemUpdateBinding, OrderItem>();
            #endregion
            #region Product

            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductUpdateBinding, Product>();
            CreateMap<ProductBinding, Product>();
            CreateMap<ProductCategory, ProductCategoryViewModel>();
            CreateMap<ProductCategoryUpdateBinding, ProductCategory>();
            CreateMap<ProductCategoryBinding, ProductCategory>();

            CreateMap<QuantityType, QuantityTypeViewModel>();
            #endregion
            #region Common
            CreateMap<AddressBinding, Addresss>();
            CreateMap<AddressUpdateBinding, Addresss>();
            CreateMap<Addresss, AddressViewModel>();
            CreateMap<Addresss, AddressBinding>();
            CreateMap<AspNetUser, ApplicationUserViewModel>();
            CreateMap<ApplicationUserUpdateBinding, AspNetUser>();
            CreateMap<AddressViewModel, AddressUpdateBinding>();
            #endregion
            #region Document
            CreateMap<Document, DocumentViewModel>();
            #endregion




        }
    }
}
