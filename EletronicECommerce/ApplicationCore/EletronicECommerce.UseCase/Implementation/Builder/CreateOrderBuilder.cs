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
            RegisterOrderUseCaseValidation.Validate(_order, _orderRepository, _productRepository);
            
            return this;
        }
    }
}