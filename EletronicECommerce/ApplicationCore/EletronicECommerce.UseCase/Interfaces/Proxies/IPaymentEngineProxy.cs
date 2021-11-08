using System.Threading.Tasks;
using EletronicECommerce.Domain.DTOs;

namespace EletronicECommerce.UseCase.Interfaces.Proxies
{
    public interface IPaymentEngineProxy
    {
        Task<object> SendPayment(Payment payment);
    }
}