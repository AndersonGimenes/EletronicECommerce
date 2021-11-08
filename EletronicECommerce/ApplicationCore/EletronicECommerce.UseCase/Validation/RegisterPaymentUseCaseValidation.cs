using EletronicECommerce.Domain.Entities.Store;
using EletronicECommerce.UseCase.Exceptions;

namespace EletronicECommerce.UseCase.Validation
{
    internal class RegisterPaymentUseCaseValidation
    {
        public void IsValid(Customer customer)
        {
            if(customer is null)
                throw new UseCaseException("Invalid customer");
        }
    }
}