using System.Linq;
using EletronicECommerce.Domain.Entities.Enums;
using EletronicECommerce.Domain.Entities.Store;
using EletronicECommerce.Domain.Validation;
using EletronicECommerce.UseCase.Interfaces.Builder;
using EletronicECommerce.UseCase.Interfaces.Repositories;
using EletronicECommerce.UseCase.Validation;

namespace EletronicECommerce.UseCase.Implementation.Builder
{
    public class CreateOrderBuilder : ICreateOrderBuilder
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private Order _order;
        public CreateOrderBuilder(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public Order CallRepository() => _orderRepository.Create(_order);

        public IBuilder<Order> Set(Order order)
        {
            _order = order;
            return this;
        }

        public IBuilder<Order> Validate()
        {
            _order.Validate();
            RegisterOrderUseCaseValidation.Validate(_order, _productRepository);

            return this;
        }

        public ICreateOrderBuilder SumTotalPrice()
        {
            var products = _productRepository.GetProductsByIds(_order.ProductsItems.Select(x => x.ProductIdentifier)).ToList();
            decimal totalPrice = default;

            products.ForEach(x =>
            {
                var quantity = _order.ProductsItems.First(p => p.ProductIdentifier == x.Identifier).Quantity;
                totalPrice += x.SalePrice * quantity;
            });

            _order.SetTotalPrice(totalPrice);

            return this;
        }

        public ICreateOrderBuilder SetStatusOrder()
        {
            _order.SetStatusOrder(StatusOrder.Selected);
            return this;
        }

        public ICreateOrderBuilder SetOrderToOrderProduct()
        {
            _order.ProductsItems.ToList().ForEach(x => x.SetOrder(_order.Identifier));
            return this;
        }
    }
}