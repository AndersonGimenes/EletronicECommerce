using EletronicECommerce.Domain.Entities.Store;
using EletronicECommerce.Domain.Validation.ValueObjectValidation;

namespace EletronicECommerce.Domain.Validation
{
    public static class CustomerExtensionsValidation
    {
        public static void IsValid(this Customer customer)
        {
            customer.Document.IsValid();
        }
    }
}