using System;
using EletronicECommerce.Domain.Entities.Admin;
using EletronicECommerce.UseCase.Implementation.Builders;
using EletronicECommerce.UseCase.Implementation.UseCase;
using EletronicECommerce.UseCase.Interfaces.Repositories;
using Xunit;
using Moq;
using EletronicECommerce.UseCase.Exceptions;

namespace EletronicECommerce.UnitTest.UseCase
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
                .Setup(x => x.GetByIdentifier(It.IsAny<Guid>()))
                .Returns(new Category("Consoles"));
            
            _registerProductUseCase = new RegisterProductUseCase(new CreateProductBuilder(_productRepositoryMock.Object, _categoryRepositoryMock.Object));
        }

        [Fact]
        public void MustHaveAValidProductToBeCreated()
        {
            _categoryRepositoryMock
                .Setup(x => x.GetByIdentifier(It.IsAny<Guid>()))
                .Returns(new Category("Consoles"));

            var product = CreateNewProduct();

            var result = _registerProductUseCase.Create(product);

            Assert.True(result.Identifier != Guid.Empty);
        }

        [Fact]
        public void IfHaveMoreThanOneSameProductNameShouldThrowAnUseCaseException()
        {
            var product = CreateNewProduct(); 

            _productRepositoryMock
                .Setup(x => x.GetByName(It.IsAny<string>()))
                .Returns(CreateNewProduct());

            var ex = Assert.Throws<UseCaseException>(() => _registerProductUseCase.Create(product));

            Assert.Equal("The Playstation 5 product name already exists.", ex.Message);

        }
        
	    [Fact]
        public void IfHaveMoreThanOneSameProductCodeShouldThrowAnUseCaseException()
        {
            var product = CreateNewProduct(); 
            
            _productRepositoryMock
                .Setup(x => x.GetByCode(It.IsAny<string>()))
                .Returns(CreateNewProduct());

            var ex = Assert.Throws<UseCaseException>(() => _registerProductUseCase.Create(product));

            Assert.Equal("The PS5 product code already exists.", ex.Message);

        }
	    
        [Fact]
        public void IfDoesNotHaveAnyValidCategoriesShouldThrowAnUseCaseException()
        {
            _categoryRepositoryMock
                .Setup(x => x.GetByIdentifier(It.IsAny<Guid>()))
                .Returns(() => null);

            var product = CreateNewProduct(); 
            
            var ex = Assert.Throws<UseCaseException>(() => _registerProductUseCase.Create(product));

            Assert.Equal("Please select any valid category.", ex.Message);

        }

        [Fact]
        public void IfHaveAnInValidProductShouldThrowAnUseCaseException()
        {
            var product = CreateNewProduct(); 

            _productRepositoryMock
                .Setup(x => x.GetByName(It.IsAny<string>()))
                .Returns(CreateNewProduct());
            
            _productRepositoryMock
                .Setup(x => x.GetByCode(It.IsAny<string>()))
                .Returns(CreateNewProduct());

            _categoryRepositoryMock
                .Setup(x => x.GetByIdentifier(It.IsAny<Guid>()))
                .Returns(() => null);

            var ex = Assert.Throws<UseCaseException>(() => _registerProductUseCase.Create(product));

            Assert.Equal("The Playstation 5 product name already exists.The PS5 product code already exists.Please select any valid category.", ex.Message);

        }

        private Product CreateNewProduct() =>
            new Product("Playstation 5", "PS5", 300, 499.99m, 5, Guid.NewGuid());
    }
}