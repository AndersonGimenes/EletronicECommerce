using EletronicECommerce.Domain.Entities.Store;
using EletronicECommerce.UseCase.Interfaces.Builder;
using EletronicECommerce.UseCase.Interfaces.UseCase;

namespace EletronicECommerce.UseCase.Implementation.UseCase
{
    public class RegisterOrderUseCase : RegisterBaseUseCase<Order>, IRegisterOrderUseCase
    {
        private readonly ICreateOrderBuilder _builder;
        public RegisterOrderUseCase(ICreateOrderBuilder builder) 
            : base(builder)
        {
            _builder = builder;
        }

        public override Order Create(Order order)
        {
            var builder = _builder
                            .Set(order)
                            .Validate() as ICreateOrderBuilder;

            var entityReady = builder
                                .SetStatusOrder()
                                .SumTotalPrice()
                                .SetOrderToOrderProduct()
                                .CallRepository();

             return entityReady;
        }
    }

}