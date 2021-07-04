using EletronicECommerce.Domain.Entities.Store;
using EletronicECommerce.UseCase.Interfaces.Builder;
using EletronicECommerce.UseCase.Interfaces.UseCase;

namespace EletronicECommerce.UseCase.Implementation.UseCase
{
    public class RegisterCustomerUseCase : RegisterBaseUseCase<Customer>, IRegisterCustomerUseCase
    {
        public RegisterCustomerUseCase(ICreateCustomerBuilder createCustomerBuilder) 
            : base(createCustomerBuilder)
        {
        }

        public void Update(Customer customer)
        {
            throw new System.NotImplementedException();
        }
    }
}