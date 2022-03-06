using AutoMapper;
using EletronicECommerce.Api.Models.Category;
using EletronicECommerce.Api.Models.Customer;
using EletronicECommerce.Api.Models.Payment;
using EletronicECommerce.Api.Models.Product;
using EletronicECommerce.Api.Models.User;
using EletronicECommerce.Domain.Entities.Admin;
using EletronicECommerce.Domain.DTOs;
using EletronicECommerce.Domain.Entities.Enums;
using EletronicECommerce.Domain.Entities.Shared;
using EletronicECommerce.Domain.Entities.Store;
using VO = EletronicECommerce.Domain.Entities.ValeuObjects;
using EletronicECommerce.Api.Models.Order;

namespace EletronicECommerce.Api.Mapping
{
    public class MappingProfileApi : Profile
    {
        public MappingProfileApi()
        {
            #region [Api to Domain]
            
            CreateMap<UserRequest, User>()
                .ForMember(dest => dest.Role, opts => opts.MapFrom(x => RoleType.CommonUser));
                
            CreateMap<CategoryRequest, Category>();

            CreateMap<Stock, VO.Stock>();
            CreateMap<ProductRequest, Product>()
                .ForPath(dest => dest.Stocks, opts => opts.MapFrom(x => x.Stocks));
     
            CreateMap<Name, VO.Name>();
            CreateMap<Address, VO.Address>();
            CreateMap<Document, VO.Document>()
                .ForMember(dest => dest.DocumentType, opts => opts.MapFrom(x => x.Number.Length == 11 ? DocumentType.CPF : DocumentType.CNPJ));

            CreateMap<CustomerRequest, Customer>()
                .ForPath(dest => dest.FullName, opts => opts.MapFrom(x => x.FullName))
                .ForPath(dest => dest.Document, opts => opts.MapFrom(x => x.Document));

            CreateMap<PaymentRequest, Payment>();

            CreateMap<OrderProduct, VO.OrderProduct>();

            CreateMap<OrderRequest, Order>()
                .ForPath(dest => dest.ProductsItems, opts => opts.MapFrom(x => x.ProductsItems));

            #endregion

            #region [Domain to Api]

            CreateMap<Category, CategoryResponse>();

            CreateMap<VO.Stock, Stock>();
            CreateMap<Product, ProductResponse>()
                .ForPath(dest => dest.Stocks, opts => opts.MapFrom(x => x.Stocks));

            CreateMap<VO.Name, Name>();
            CreateMap<VO.Address, Address>();
            CreateMap<VO.Document, Document>()
                .ForMember(dest => dest.DocumentType, opts => opts.MapFrom(x => x.Number.Length == 11 ? DocumentType.CPF.ToString() : DocumentType.CNPJ.ToString()));

            CreateMap<Customer, CustomerResponse>()
                .ForPath(dest => dest.FullName, opts => opts.MapFrom(x => x.FullName))
                .ForPath(dest => dest.Document, opts => opts.MapFrom(x => x.Document));

            CreateMap<VO.OrderProduct, OrderProduct>();

            CreateMap<Order, OrderResponse>()
                .ForPath(dest => dest.ProductsItems, opts => opts.MapFrom(x => x.ProductsItems));

            #endregion
        }
    }
}