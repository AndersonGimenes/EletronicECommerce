using System;
using EletronicECommerce.Domain.Entities.Admin;
using EletronicECommerce.UseCase.Implementation.Builder;
using EletronicECommerce.UseCase.Implementation.UseCase;
using EletronicECommerce.UseCase.Interfaces.Repositories;
using Xunit;
using Moq;
using EletronicECommerce.UseCase.Exceptions;

namespace EletronicECommerce.UnitTest.UseCase
{
    public class RegisterCategoryUseCaseTest
    {
        private readonly RegisterCategoryUseCase _registerCategoryUseCase;
        private readonly Mock<ICategoryRepository> _categoryRepositoryMock;

        public RegisterCategoryUseCaseTest()
        {
            _categoryRepositoryMock = new Mock<ICategoryRepository>();

            _registerCategoryUseCase = new RegisterCategoryUseCase(new CreateCategoryBuilder(_categoryRepositoryMock.Object));
        }

        [Fact]
        public void MustHaveAValidCategoryToBeCreated()
        {
            var category = new Category("Games", Guid.Empty);

            _categoryRepositoryMock
                .Setup(x => x.Create(It.IsAny<Category>()))
                .Returns(category);

            var result = _registerCategoryUseCase.Create(category);

            Assert.True(result.Identifier != Guid.Empty);
        }

        [Fact]
        public void IfHaveMoreThanOneSameCategoryNameShouldThrowAnUseCaseException()
        {
            _categoryRepositoryMock
                .Setup(x => x.GetByName(It.IsAny<string>()))
                .Returns(new Category("Consoles", Guid.Empty));

            var category = new Category("Consoles", Guid.Empty);

            var ex = Assert.Throws<UseCaseException>(() => _registerCategoryUseCase.Create(category));

            Assert.Equal("The Consoles category name already exists.", ex.Message);
        }

        //[TO-DO] Implements this methods
        //if have a product referenced with any category shoud throw an exception

        //must delete a category if there is not product referenced with the one        
    }
}