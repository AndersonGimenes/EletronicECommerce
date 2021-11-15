using EletronicECommerce.Domain.Entities.ValeuObjects;
using EletronicECommerce.Domain.Exceptions;

namespace EletronicECommerce.Domain.Validation.ValueObjectValidation
{
    internal static class StockExtensionsValidation
    {
        internal static void Validate(this Stock stock)
        {
            if(stock.Quantity <= 0)
                throw new DomainException($"The {nameof(Stock.Quantity)} must be bigger than zero.");

            if(stock.PurchasePrice < 0)
                throw new DomainException($"The {nameof(Stock.PurchasePrice)} must be bigger or equal than zero.");
        }
    }
}