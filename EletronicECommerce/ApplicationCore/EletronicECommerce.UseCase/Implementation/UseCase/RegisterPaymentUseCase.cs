using System.Threading.Tasks;
using EletronicECommerce.Domain.DTOs;
using EletronicECommerce.Domain.Validation;
using EletronicECommerce.UseCase.Interfaces.Proxies;
using EletronicECommerce.UseCase.Interfaces.Repositories;
using EletronicECommerce.UseCase.Interfaces.UseCase;
using EletronicECommerce.UseCase.Validation;

namespace EletronicECommerce.UseCase.Implementation.UseCase
{
    public class RegisterPaymentUseCase : IRegisterPaymentUseCase
    {
        private readonly IPaymentEngineProxy _paymentEngineProxy;
        private readonly ICustomerRepository _customerRepository;

        public RegisterPaymentUseCase(IPaymentEngineProxy paymentEngineProxy, ICustomerRepository customerRepository)
        {
            _paymentEngineProxy = paymentEngineProxy;
            _customerRepository = customerRepository;
        }
        public object SendPayment(Payment payment)
        {
            payment.Validate();
            CustomMapper(payment);

            var result = Task.Run( () => _paymentEngineProxy.SendPayment(payment)).Result;
            
            return result;
        }

        private void CustomMapper(Payment payment)
        {
            var customer = _customerRepository.GetByUserIdentifier(payment.CustomerId);
            RegisterPaymentUseCaseValidation.Validate(customer);
            
            payment.SetCustomer(customer.FullName);
        }
    }
}