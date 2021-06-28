using System;
using EletronicECommerce.Domain.Entities.Admin;
using EletronicECommerce.UseCase.Implementation.Builders;
using EletronicECommerce.UseCase.Implementation.UseCase;
using EletronicECommerce.UseCase.Interfaces.Repositores;
using Xunit;
using Moq;
using EletronicECommerce.UseCase.Exceptions;
using Moq.Language.Flow;

namespace EletronicECommerce.UnitTest.UseCase
{
    public class RegisterCategoryUseCaseTest
    {
        private readonly RegisterCategoryUseCase _registerCategoryUseCase;
        private ISetup<ICategoryRepository, Category> _categoryRepositoryGetByNameMock;
        
        public RegisterCategoryUseCaseTest()
        {
            var categoryRepositoryMock = new Mock<ICategoryRepository>();

            _categoryRepositoryGetByNameMock = categoryRepositoryMock
                .Setup(x => x.GetByName(It.IsAny<string>()));
            
            _registerCategoryUseCase = new RegisterCategoryUseCase(new CreateCategoryBuilder(categoryRepositoryMock.Object));
        }

        [Fact]
        public void MustHaveAValidCategoryToBeCreated()
        {
            _categoryRepositoryGetByNameMock
                .Returns(() => null);

            var category = new Category("Games");

            var result = _registerCategoryUseCase.Create(category);

            Assert.True(result.Identifier != Guid.Empty);
        }

        [Fact]
        public void IfHaveMoreThanOneSameCategoryNameShouldAnUseCaseException()
        {
            _categoryRepositoryGetByNameMock
                .Returns(new Category("Consoles"));

            var category = new Category("Consoles");

            var ex = Assert.Throws<UseCaseException>(() => _registerCategoryUseCase.Create(category));

            Assert.Equal("The Consoles category already exists.", ex.Message);
        }

        //[TO-DO] Implements this methods
        //if have a product referenced with any category shoud throw an exception

        //must delete a category if there is not product referenced with the one        
    }
}