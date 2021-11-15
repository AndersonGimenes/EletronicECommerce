using EletronicECommerce.Domain.Entities.ValeuObjects;
using EletronicECommerce.Domain.Exceptions;

namespace EletronicECommerce.Domain.Validation.ValueObjectValidation
{
    internal static class DocumentExtensionsValidation
    {
        internal static void Validate(this Document document)
        {
            if(document.Number.Length < 11 || document.Number.Length > 14)
                throw new DomainException("The document number must be between 11 and 14 chacacters long.");
        }
    }
}