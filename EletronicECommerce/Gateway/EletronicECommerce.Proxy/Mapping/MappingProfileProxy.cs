using AutoMapper;
using DTO = EletronicECommerce.Domain.DTOs;
using EletronicECommerce.Proxy.Model.Cielo;
using EletronicECommerce.Proxy.Model.Cielo.ChildClass;
using EletronicECommerce.Domain.Entities.ValeuObjects;

namespace EletronicECommerce.Proxy.Mapping
{
    public class MappingProfileProxy : Profile
    {
        public MappingProfileProxy()
        {
            CreateMap<DTO.Payment, CreditCard>();

            CreateMap<DTO.Payment, Payment>()
                .ForPath(dest => dest.CreditCard, opts => opts.MapFrom(x => x));

            CreateMap<Name, Customer>()
                .ForMember(dest => dest.Name, opts => opts.MapFrom(x => $"{x.FirstName} {x.Surname}"));            

            CreateMap<DTO.Payment, CieloPaymentRequest>()
                .ForPath(dest => dest.Payment, opts => opts.MapFrom(x => x))
                .ForPath(dest => dest.Customer, opts => opts.MapFrom(x => x.Customer));
        }
    }
}