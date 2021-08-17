using AutoMapper;
using EletronicECommerce.Api.Models.Category;
using EletronicECommerce.Api.Models.Product;
using EletronicECommerce.Api.Models.User;
using EletronicECommerce.Domain.Entities.Admin;
using EletronicECommerce.Domain.Entities.Shared;

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

            #endregion

            #region [Domain to Api]

            CreateMap<Category, CategoryResponse>();
            CreateMap<Product, ProductResponse>();

            #endregion
        }
    }
}