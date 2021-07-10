using AutoMapper;
using EletronicECommerce.Api.Models.User;
using EletronicECommerce.Domain.Entities.Shared;

namespace EletronicECommerce.Api.Mapping
{
    public class MappingProfileApi : Profile
    {
        public MappingProfileApi()
        {
            #region [Api to Domain]
            
            CreateMap<UserRequest, User>();

            #endregion

            #region [Domain to Api]
            #endregion
        }
    }
}