using System.Linq;
using EletronicECommerce.Domain.Entities.Store;
using EletronicECommerce.Domain.Exceptions;

namespace EletronicECommerce.Domain.Validation
{
    public static class OrderExtensionsValidation
    {
        public static void Validate(this Order order)
        {
            if(order.Products is null || order.Products.Count() == 0)
                throw new DomainException($"The {nameof(Order.Products)} list must have at least one product.");
        }
    }
}