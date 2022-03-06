using EletronicECommerce.Domain.Entities.Store;

namespace EletronicECommerce.UseCase.Interfaces.Builder
{
    public interface ICreateOrderBuilder : IBuilder<Order>
    {
        ICreateOrderBuilder SumTotalPrice();
        ICreateOrderBuilder SetStatusOrder();
        ICreateOrderBuilder SetOrderToOrderProduct();
    }
}