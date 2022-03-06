using AutoMapper;
using EletronicECommerce.Domain.Entities.Admin;
using EletronicECommerce.Domain.Entities.Shared;
using EletronicECommerce.Domain.Entities.Store;
using EletronicECommerce.Domain.Entities.ValeuObjects;
using EletronicECommerce.Repository.Models;
using EletronicECommerce.Repository.Models.SubModels;

namespace EletronicECommerce.Repository.Mapping
{
    public class MappingProfileRepository : Profile
    {
        public MappingProfileRepository()
        {
            #region [Model To Domain]
            CreateMap<UserModel, User>()
                .ForMember(dest => dest.Identifier, opts => opts.MapFrom(x => x.Id));

            CreateMap<CategoryModel, Category>()
                .ForMember(dest => dest.Identifier, opts => opts.MapFrom(x => x.Id));

            CreateMap<StockModel, Stock>();

            CreateMap<ProductModel, Product>()
                .ForMember(dest => dest.Identifier, opts => opts.MapFrom(x => x.Id))
                .ForPath(dest => dest.Stocks, opts => opts.MapFrom(x => x.Stocks));

            CreateMap<AddressModel, Address>();

            CreateMap<CustomerModel, Name>()
                .ForMember(dest => dest.FirstName, opts => opts.MapFrom(x => x.FirstName))
                .ForMember(dest => dest.Surname, opts => opts.MapFrom(x => x.Surname));

            CreateMap<CustomerModel, Document>()
                .ForMember(dest => dest.Number, opts => opts.MapFrom(x => x.DocumentNumber))
                .ForMember(dest => dest.DocumentType, opts => opts.MapFrom(x => x.DocumentType));

            CreateMap<CustomerModel, Customer>()
                .ForMember(dest => dest.Identifier, opts => opts.MapFrom(x => x.Id))
                .ForMember(dest => dest.UserIdentifier, opts => opts.MapFrom(x => x.UserId));

            CreateMap<OrderProductModel, OrderProduct>()
                .ForMember(dest => dest.ProductIdentifier, opts => opts.MapFrom(x => x.ProductId));

            CreateMap<OrderModel, Order>()
                .ForMember(dest => dest.Identifier, opts => opts.MapFrom(x => x.Id))
                .ForMember(dest => dest.UserIdentifier, opts => opts.MapFrom(x => x.UserId))
                .ForPath(dest => dest.ProductsItems, opts => opts.MapFrom(x => x.Products));

            #endregion

            #region [Domain To Model]
            CreateMap<User, UserModel>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(x => x.Identifier));

            CreateMap<Category, CategoryModel>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(x => x.Identifier));

            CreateMap<Stock, StockModel>();

            CreateMap<Product, ProductModel>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(x => x.Identifier))
                .ForMember(dest => dest.CategoryId, opts => opts.MapFrom(x => x.CategoryIdentifier))
                .ForPath(dest => dest.Stocks, opts => opts.MapFrom(x => x.Stocks));

            CreateMap<Address, AddressModel>();

            CreateMap<Customer, CustomerModel>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(x => x.Identifier))
                .ForMember(dest => dest.FirstName, opts => opts.MapFrom(x => x.FullName.FirstName))
                .ForMember(dest => dest.Surname, opts => opts.MapFrom(x => x.FullName.Surname))
                .ForMember(dest => dest.DocumentNumber, opts => opts.MapFrom(x => x.Document.Number))
                .ForMember(dest => dest.DocumentType, opts => opts.MapFrom(x => x.Document.DocumentType))
                .ForMember(dest => dest.UserId, opts => opts.MapFrom(x => x.UserIdentifier))
                .ForPath(dest => dest.Addresses, opts => opts.MapFrom(x => x.Addresses));

            CreateMap<OrderProduct, OrderProductModel>()
                .ForMember(dest => dest.ProductId, opts => opts.MapFrom(x => x.ProductIdentifier))
                .ForMember(dest => dest.OrderId, opts => opts.MapFrom(x => x.OrderIdentifier));

            CreateMap<Order, OrderModel>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(x => x.Identifier))
                .ForMember(dest => dest.UserId, opts => opts.MapFrom(x => x.UserIdentifier))
                .ForPath(dest => dest.Products, opts => opts.MapFrom(x => x.ProductsItems));

            #endregion
        }
    }
}