using System.Collections.Generic;
using System.Linq;
using EletronicECommerce.Domain.Entities.Admin;
using EletronicECommerce.Domain.Entities.Store;
using EletronicECommerce.UseCase.Exceptions;
using EletronicECommerce.UseCase.Interfaces.Repositories;

namespace EletronicECommerce.UseCase.Validation
{
    internal static class RegisterOrderUseCaseValidation
    {
        internal static void Validate(Order order, IProductRepository productRepository)
        {
            var products = productRepository.GetProductsByIds(order.ProductsItems.Select(x => x.ProductIdentifier));

            if (products.Count() == 0)
                throw new UseCaseException($"Some {nameof(Order.ProductsItems)} there aren't in the selection. Please select the products again.");

            if (!products.All(x => x.Stocks.Sum(x => x.Quantity) != default))
                throw new UseCaseException($"There aren't {nameof(Order.ProductsItems)} {nameof(Product.Stocks)} the selection. Please select the products again.");

            if (RequestQuantityIsGreaterThanStock(products, order))
                throw new UseCaseException($"The selected quantity is greater than actual stock.");
        }

        private static bool RequestQuantityIsGreaterThanStock(IEnumerable<Product> products, Order order) =>
            products.Any(x =>
            {
                var quantity = order.ProductsItems.First(p => p.ProductIdentifier == x.Identifier).Quantity;
                var productQuantity = x.Stocks.Sum(x => x.Quantity);

                return quantity > productQuantity;
            });
    }
}