using AutoMapper;
using EletronicECommerce.Domain.Entities.Admin;
using EletronicECommerce.Domain.Entities.Shared;
using EletronicECommerce.Repository.Models;

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
            #endregion

            #region [Domain To Model]
            CreateMap<User, UserModel>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(x => x.Identifier));

            CreateMap<Category, CategoryModel>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(x => x.Identifier));
            #endregion
        }
    }
}