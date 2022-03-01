using EletronicECommerce.Domain.Entities.Admin;
using EletronicECommerce.Domain.Exceptions;
using EletronicECommerce.Domain.Validation.ValueObjectValidation;

namespace EletronicECommerce.Domain.Validation
{
    public static class ProductExtensionsValidation
    {
        public static void Validate(this Product product)
        {
            if(product.SalePrice <= 0)
                throw new DomainException($"The {nameof(Product.SalePrice)} must be bigger than zero.");

            if(product.Stocks != null)
            {
                foreach (var stock in product.Stocks)
                {
                    stock.Validate();
                }
            }                
        }
    }
}