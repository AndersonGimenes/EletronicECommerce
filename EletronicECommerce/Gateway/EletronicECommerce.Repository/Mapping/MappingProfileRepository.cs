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
                .ForPath(dest => dest.Stock, opts => opts.MapFrom(x => x.Stock));

            CreateMap<AddressModel, Address>(); 

            CreateMap<CustomerModel, Name>()
                .ForMember(dest => dest.FirstName, opts => opts.MapFrom(x => x.FirstName))
                .ForMember(dest => dest.Surname, opts => opts.MapFrom(x => x.Surname));

            CreateMap<CustomerModel, Document>()
                .ForMember(dest => dest.Number, opts => opts.MapFrom(x => x.DocumentNumber))
                .ForMember(dest => dest.DocumentType, opts => opts.MapFrom(x => x.DocumentType));

            CreateMap<CustomerModel, Customer>()
                .ForMember(dest => dest.Identifier, opts => opts.MapFrom(x => x.Id))
                .ForPath(dest => dest.BillingAddress, opts => opts.MapFrom(x => x.BillingAddress))
                .ForPath(dest => dest.DeliveryAddess, opts => opts.MapFrom(x => x.DeliveryAddess));      

            #endregion

            #region [Domain To Model]
            CreateMap<User, UserModel>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(x => x.Identifier));

            CreateMap<Category, CategoryModel>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(x => x.Identifier));

            CreateMap<Stock, StockModel>();

            CreateMap<Product, ProductModel>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(x => x.Identifier))
                .ForPath(dest => dest.Stock, opts => opts.MapFrom(x => x.Stock));

            CreateMap<Address, AddressModel>(); 

            CreateMap<Customer, CustomerModel>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(x => x.Identifier))
                .ForMember(dest => dest.FirstName, opts => opts.MapFrom(x => x.FullName.FirstName))
                .ForMember(dest => dest.Surname, opts => opts.MapFrom(x => x.FullName.Surname))
                .ForMember(dest => dest.DocumentNumber, opts => opts.MapFrom(x => x.Document.Number))
                .ForMember(dest => dest.DocumentType, opts => opts.MapFrom(x => x.Document.DocumentType))
                .ForPath(dest => dest.BillingAddress, opts => opts.MapFrom(x => x.BillingAddress))
                .ForPath(dest => dest.DeliveryAddess, opts => opts.MapFrom(x => x.DeliveryAddess));

            #endregion
        }
    }
}