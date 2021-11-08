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

namespace EletronicECommerce.Api.Mapping
{
    public class MappingProfileApi : Profile
    {
        public MappingProfileApi()
        {
            #region [Api to Domain]
            
            CreateMap<UserRequest, User>();
            CreateMap<CategoryRequest, Category>();

            CreateMap<Stock, VO.Stock>();
            CreateMap<ProductRequest, Product>()
                .ForPath(dest => dest.Stock, opts => opts.MapFrom(x => x.Stock));
     
            CreateMap<Name, VO.Name>();
            CreateMap<Address, VO.Address>();
            CreateMap<Document, VO.Document>()
                .ForMember(dest => dest.DocumentType, opts => opts.MapFrom(x => x.Number.Length == 11 ? DocumentType.CPF : DocumentType.CNPJ));

            CreateMap<CustomerRequest, Customer>()
                .ForPath(dest => dest.FullName, opts => opts.MapFrom(x => x.FullName))
                .ForPath(dest => dest.Document, opts => opts.MapFrom(x => x.Document))
                .ForPath(dest => dest.BillingAddress, opts => opts.MapFrom(x => x.BillingAddress))
                .ForPath(dest => dest.DeliveryAddess, opts => opts.MapFrom(x => x.DeliveryAddess));

            CreateMap<PaymentRequest, Payment>();

            #endregion

            #region [Domain to Api]

            CreateMap<Category, CategoryResponse>();

            CreateMap<VO.Stock, Stock>();
            CreateMap<Product, ProductResponse>()
                .ForPath(dest => dest.Stock, opts => opts.MapFrom(x => x.Stock));

            CreateMap<VO.Name, Name>();
            CreateMap<VO.Address, Address>();
            CreateMap<VO.Document, Document>()
                .ForMember(dest => dest.DocumentType, opts => opts.MapFrom(x => x.Number.Length == 11 ? DocumentType.CPF.ToString() : DocumentType.CNPJ.ToString()));

            CreateMap<Customer, CustomerResponse>()
                .ForPath(dest => dest.FullName, opts => opts.MapFrom(x => x.FullName))
                .ForPath(dest => dest.Document, opts => opts.MapFrom(x => x.Document))
                .ForPath(dest => dest.BillingAddress, opts => opts.MapFrom(x => x.BillingAddress))
                .ForPath(dest => dest.DeliveryAddess, opts => opts.MapFrom(x => x.DeliveryAddess));

            #endregion
        }
    }
}