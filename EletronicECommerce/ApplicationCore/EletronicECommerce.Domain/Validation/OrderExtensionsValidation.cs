using System.Linq;
using EletronicECommerce.Domain.Entities.Store;
using EletronicECommerce.Domain.Exceptions;

namespace EletronicECommerce.Domain.Validation
{
    public static class OrderExtensionsValidation
    {
        public static void Validate(this Order order)
        {
            if(order.ProductsItems is null || order.ProductsItems.Count() == 0)
                throw new DomainException($"The {nameof(Order.ProductsItems)} list must have at least one product.");
        }
    }
}