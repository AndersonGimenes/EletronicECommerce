using AutoMapper;
using EletronicECommerce.Api.Models.Category;
using EletronicECommerce.Api.Models.Customer;
using EletronicECommerce.Api.Models.Product;
using EletronicECommerce.Api.Models.User;
using EletronicECommerce.Domain.Entities.Admin;
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
            CreateMap<ProductRequest, Product>();

            CreateMap<Name, VO.Name>();
            CreateMap<Address, VO.Address>();
            CreateMap<Document, VO.Document>()
                .ForMember(dest => dest.DocumentType, opts => opts.MapFrom(x => x.Number.Length == 11 ? DocumentType.CPF : DocumentType.CNPJ));

            CreateMap<CustomerRequest, Customer>()
                .ForPath(dest => dest.FullName, opts => opts.MapFrom(x => x.FullName))
                .ForPath(dest => dest.Document, opts => opts.MapFrom(x => x.Document))
                .ForPath(dest => dest.BillingAddress, opts => opts.MapFrom(x => x.BillingAddress))
                .ForPath(dest => dest.DeliveryAddess, opts => opts.MapFrom(x => x.DeliveryAddess));

            #endregion

            #region [Domain to Api]

            CreateMap<Category, CategoryResponse>();
            CreateMap<Product, ProductResponse>();

            #endregion
        }
    }
}