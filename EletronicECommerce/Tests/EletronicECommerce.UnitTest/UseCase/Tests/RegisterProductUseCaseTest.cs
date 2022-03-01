using System;
using EletronicECommerce.Domain.Entities.Admin;
using EletronicECommerce.UseCase.Implementation.Builder;
using EletronicECommerce.UseCase.Implementation.UseCase;
using EletronicECommerce.UseCase.Interfaces.Repositories;
using Xunit;
using Moq;
using EletronicECommerce.UseCase.Exceptions;
using EletronicECommerce.Domain.Exceptions;
using Mock = EletronicECommerce.UnitTest.UseCase.MockObjects.MockObjects;

namespace EletronicECommerce.UnitTest.UseCase.Tests
{
    public class RegisterProductUseCaseTest
    {
        private readonly RegisterProductUseCase _registerProductUseCase;
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly Mock<ICategoryRepository> _categoryRepositoryMock;

        public RegisterProductUseCaseTest()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _categoryRepositoryMock = new Mock<ICategoryRepository>();

            _categoryRepositoryMock
                .Setup(x => x.GetByIdentifier(It.IsAny<Guid>(), It.IsAny<string>()))
                .Returns(Mock.NewCategoryInstance("Games"));

            _productRepositoryMock
                .Setup(x => x.Create(It.IsAny<Product>()))
                .Returns(Mock.NewProductInstance(null,499.99m));
            
            _registerProductUseCase = new RegisterProductUseCase(new CreateProductBuilder(_productRepositoryMock.Object, _categoryRepositoryMock.Object));
        }

        [Fact]
        public void MustHaveAValidProductToBeCreated()
        {
            var product = Mock.NewProductInstance(null,499.99m);

            var result = _registerProductUseCase.Create(product);

            Assert.True(result.Identifier != Guid.Empty);
        }

        [Fact]
        public void IfHaveMoreThanOneSameProductNameShouldThrowAnUseCaseException()
        {
            var product = Mock.NewProductInstance(null,499.99m); 

            _productRepositoryMock
                .Setup(x => x.GetByName(It.IsAny<string>()))
                .Returns(product);

            var ex = Assert.Throws<UseCaseException>(() => _registerProductUseCase.Create(product));

            Assert.Equal("The Playstation 5 product name already exists.", ex.Message);

        }
        
	    [Fact]
        public void IfHaveMoreThanOneSameProductCodeShouldThrowAnUseCaseException()
        {
            var product = Mock.NewProductInstance(null,499.99m); 
            
            _productRepositoryMock
                .Setup(x => x.GetByCode(It.IsAny<string>()))
                .Returns(product);

            var ex = Assert.Throws<UseCaseException>(() => _registerProductUseCase.Create(product));

            Assert.Equal("The PS5 product code already exists.", ex.Message);

        }
	    
        [Fact]
        public void IfDoesNotHaveAnyValidCategoriesShouldThrowAnUseCaseException()
        {
            _categoryRepositoryMock
                .Setup(x => x.GetByIdentifier(It.IsAny<Guid>(), It.IsAny<string>()))
                .Returns(() => null);

            var product = Mock.NewProductInstance(null,499.99m); 
            
            var ex = Assert.Throws<UseCaseException>(() => _registerProductUseCase.Create(product));

            Assert.Equal("Please select any valid category.", ex.Message);

        }

        [Fact]
        public void MustHaveAValueBiggerThanZeroForSalePrice()
        {
            var product = Mock.NewProductInstance(null,0);
            
            var ex = Assert.Throws<DomainException>(() => _registerProductUseCase.Create(product));

            Assert.Equal("The SalePrice must be bigger than zero.", ex.Message);
        }

        [Fact]
        public void WhenCreatedANewRegisterTheQuantityMustBeBiggerThanZero()
        {
            var product = Mock.NewProductInstance(Mock.NewStoksInstance(100.00m, 0),499.99m); 
            
            var ex = Assert.Throws<DomainException>(() => _registerProductUseCase.Create(product));

            Assert.Equal("The Quantity must be bigger than zero.", ex.Message);
        }

        [Fact]
        public void WhenCreatedANewRegisterThePurchasePriceMustBeBiggerOrEqualThanZero()
        {
            var product = Mock.NewProductInstance(Mock.NewStoksInstance(-2, 10),499.99m); 
            
            var ex = Assert.Throws<DomainException>(() => _registerProductUseCase.Create(product));

            Assert.Equal("The PurchasePrice must be bigger or equal than zero.", ex.Message);
        }
    }
}