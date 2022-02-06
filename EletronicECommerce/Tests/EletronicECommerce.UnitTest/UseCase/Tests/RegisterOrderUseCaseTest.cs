using System;
using System.Collections.Generic;
using EletronicECommerce.Domain.Entities.Admin;
using EletronicECommerce.Domain.Entities.Store;
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

            orderRepository.Setup(x => x.Create(It.IsAny<Order>())).Returns(MockObjects.NewOrderObject(new Guid[]{Guid.NewGuid()}));

            _useCase = new RegisterOrderUseCase(new CreateOrderBuilder(orderRepository.Object, _productRepository.Object));
        }

        [Fact]
        public void MustCreateANewOrderWithSuccess()
        {
            _productRepository
                .Setup(x => x.GetProductsByIds(It.IsAny<Guid[]>()))
                .Returns(Products(new int[]{5, 5}));

            var order = MockObjects.NewOrderObject(new Guid[]{Guid.NewGuid(), Guid.NewGuid()});

            var result = _useCase.Create(order);

            Assert.NotNull(result);
            Assert.True(result.Identifier != default);
        }

        [Fact]
        public void IfProductIsNullInOrderListMustThrowDomainException()
        {
            var order = MockObjects.NewOrderObject(null);

            var result = Assert.Throws<DomainException>(() => _useCase.Create(order));

            Assert.Equal("The Products list must have at least one product.", result.Message);
        }

        [Fact]
        public void IfThereArentAnyProductInOrderListMustThrowDomainException()
        {
            var order = MockObjects.NewOrderObject(new Guid[] { });

            var result = Assert.Throws<DomainException>(() => _useCase.Create(order));

            Assert.Equal("The Products list must have at least one product.", result.Message);
        }

        [Fact]
        public void IfThereArentAnyProductInDataBaseMustThrowUseCaseException()
        {
            var order = MockObjects.NewOrderObject(new Guid[] { Guid.NewGuid() });

            var result = Assert.Throws<UseCaseException>(() => _useCase.Create(order));

            Assert.Equal("Some Products there aren't in the selection. Please select the products again.", result.Message);
        }

        [Fact]
        public void IfThereArentAnyProductStockInDataBaseMustThrowUseCaseException()
        {
            _productRepository
                .Setup(x => x.GetProductsByIds(It.IsAny<Guid[]>()))
                .Returns(Products(new int[]{0, 5}));

            var order = MockObjects.NewOrderObject(new Guid[] { Guid.NewGuid() });

            var result = Assert.Throws<UseCaseException>(() => _useCase.Create(order));

            Assert.Equal("There aren't Products Stock the selection. Please select the products again.", result.Message);
        }

        private List<Product> Products(params int[] quantities) =>
            new List<Product> 
            {
                MockObjects.NewProductObject(MockObjects.NewStokObject(100, quantities[0]), 499.99m),
                MockObjects.NewProductObject(MockObjects.NewStokObject(100, quantities[1]), 499.99m) 
            };
    }
}