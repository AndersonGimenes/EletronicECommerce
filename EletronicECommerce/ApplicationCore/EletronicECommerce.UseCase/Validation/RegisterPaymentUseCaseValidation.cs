using EletronicECommerce.Domain.Entities.Store;
using EletronicECommerce.UseCase.Exceptions;

namespace EletronicECommerce.UseCase.Validation
{
    internal static class RegisterPaymentUseCaseValidation
    {
        internal static void Validate(Customer customer)
        {
            if(customer is null)
                throw new UseCaseException("Invalid customer");
        }
    }
}