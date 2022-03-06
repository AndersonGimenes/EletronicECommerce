using System;
using System.Collections.Generic;
using EletronicECommerce.Domain.Entities.Admin;
using EletronicECommerce.Domain.Entities.Store;
using EletronicECommerce.Domain.Entities.ValeuObjects;
using EletronicECommerce.Domain.Exceptions;
using EletronicECommerce.UseCase.Exceptions;
using EletronicECommerce.UseCase.Implementation.Builder;
using EletronicECommerce.UseCase.Implementation.UseCase;
using EletronicECommerce.UseCase.Interfaces.Repositories;
using EletronicECommerce.UseCase.Interfaces.UseCase;
using Moq;
using Xunit;

namespace EletronicECommerce.UnitTest.UseCase.MockObjects.Tests
{
    public class RegisterOrderUseCaseTest
    {
        private readonly Mock<IProductRepository> _productRepository;
        private readonly IRegisterOrderUseCase _useCase;

        public RegisterOrderUseCaseTest()
        {
            var orderRepository = new Mock<IOrderRepository>();
            _productRepository = new Mock<IProductRepository>();

            orderRepository.Setup(x => x.Create(It.IsAny<Order>())).Returns(MockObjects.NewOrderInstance(new List<OrderProduct>()));

            _useCase = new RegisterOrderUseCase(new CreateOrderBuilder(orderRepository.Object, _productRepository.Object));
        }

        [Fact]
        public void MustCreateANewOrderWithSuccess()
        {
            var products = Products(new int[] { 5, 5 });

            var itemOne = MockObjects.NewOrderProductInstance(products[0].Identifier, 2);
            var itemTwo = MockObjects.NewOrderProductInstance(products[1].Identifier, 3);

            _productRepository
                .Setup(x => x.GetProductsByIds(new Guid[] { itemOne.ProductIdentifier, itemTwo.ProductIdentifier }))
                .Returns(products);

            var order = MockObjects.NewOrderInstance(new List<OrderProduct> { itemOne, itemTwo });

            var result = _useCase.Create(order);

            Assert.NotNull(result);
            Assert.True(result.Identifier != default);
        }

        [Fact]
        public void IfProductIsNullInOrderListMustThrowDomainException()
        {
            var order = MockObjects.NewOrderInstance(null);

            var result = Assert.Throws<DomainException>(() => _useCase.Create(order));

            Assert.Equal("The ProductsItems list must have at least one product.", result.Message);
        }

        [Fact]
        public void IfThereArentAnyProductInOrderListMustThrowDomainException()
        {
            var order = MockObjects.NewOrderInstance(new List<OrderProduct>());

            var result = Assert.Throws<DomainException>(() => _useCase.Create(order));

            Assert.Equal("The ProductsItems list must have at least one product.", result.Message);
        }

        [Fact]
        public void IfThereArentAnyProductInDataBaseMustThrowUseCaseException()
        {
            var order = MockObjects.NewOrderInstance(new List<OrderProduct> { new OrderProduct() });

            var result = Assert.Throws<UseCaseException>(() => _useCase.Create(order));

            Assert.Equal("Some ProductsItems there aren't in the selection. Please select the products again.", result.Message);
        }

        [Fact]
        public void IfThereArentAnyProductStockInDataBaseMustThrowUseCaseException()
        {
            var products = Products(new int[] { 0, 5 });

            var itemOne = MockObjects.NewOrderProductInstance(products[0].Identifier, 2);
            var itemTwo = MockObjects.NewOrderProductInstance(products[1].Identifier, 3);

            _productRepository
                .Setup(x => x.GetProductsByIds(new Guid[] { itemOne.ProductIdentifier, itemTwo.ProductIdentifier }))
                .Returns(products);

            var order = MockObjects.NewOrderInstance(new List<OrderProduct> { itemOne, itemTwo });

            var result = Assert.Throws<UseCaseException>(() => _useCase.Create(order));

            Assert.Equal("There aren't ProductsItems Stocks the selection. Please select the products again.", result.Message);
        }

        [Fact]
        public void IfQuantityRequestIsGreaterThenProductStockInDataBaseMustThrowUseCaseException()
        {
            var products = Products(new int[] { 5, 1 });

            var itemOne = MockObjects.NewOrderProductInstance(products[0].Identifier, 2);
            var itemTwo = MockObjects.NewOrderProductInstance(products[1].Identifier, 3);

            _productRepository
                .Setup(x => x.GetProductsByIds(new Guid[] { itemOne.ProductIdentifier, itemTwo.ProductIdentifier }))
                .Returns(products);

            var order = MockObjects.NewOrderInstance(new List<OrderProduct> { itemOne, itemTwo });

            var result = Assert.Throws<UseCaseException>(() => _useCase.Create(order));

            Assert.Equal("The selected quantity is greater than actual stock.", result.Message);
        }

        private List<Product> Products(int[] quantities)
        {
            var products = new List<Product>
            {
                MockObjects.NewProductInstance(MockObjects.NewStoksInstance(100, quantities[0]), 499.99m),
                MockObjects.NewProductInstance(MockObjects.NewStoksInstance(100, quantities[1]), 299.00m)
            };

            return products;
        }
            
    }
}