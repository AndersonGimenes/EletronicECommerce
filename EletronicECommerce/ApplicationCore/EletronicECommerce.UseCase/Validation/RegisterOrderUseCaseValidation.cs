using System.Linq;
using EletronicECommerce.Domain.Entities.Admin;
using EletronicECommerce.Domain.Entities.Store;
using EletronicECommerce.UseCase.Exceptions;
using EletronicECommerce.UseCase.Interfaces.Repositories;

namespace EletronicECommerce.UseCase.Validation
{
    internal static class RegisterOrderUseCaseValidation
    {
        internal static void Validate(Order order, IOrderRepository orderRepository, IProductRepository productRepository)
        {
            var products = productRepository.GetProductsByIds(order.Products);
            
            if(products.Count() == 0)
                throw new UseCaseException($"Some {nameof(Order.Products)} there aren't in the selection. Please select the products again.");

            if(!products.All(x => x.Stock.Quantity != default))
                throw new UseCaseException($"There aren't {nameof(Order.Products)} {nameof(Product.Stock)} the selection. Please select the products again.");
        }
    }
}