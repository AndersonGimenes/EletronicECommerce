using EletronicECommerce.Domain.Entities.Store;
using EletronicECommerce.UseCase.Interfaces.Builder;
using EletronicECommerce.UseCase.Interfaces.UseCase;

namespace EletronicECommerce.UseCase.Implementation.UseCase
{
    public class RegisterOrderUseCase : RegisterBaseUseCase<Order>, IRegisterOrderUseCase
    {
        public RegisterOrderUseCase(ICreateOrderBuilder builder) 
            : base(builder)
        {
        }
    }
}