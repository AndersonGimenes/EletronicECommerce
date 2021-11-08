using EletronicECommerce.Domain.DTOs;

namespace EletronicECommerce.UseCase.Interfaces.UseCase
{
    public interface IRegisterPaymentUseCase
    {
        object SendPayment(Payment payment);
    }
}