using System;
using EletronicECommerce.Domain.Entities.Store;
using EletronicECommerce.Domain.Entities.ValeuObjects;
using EletronicECommerce.Domain.Exceptions;
using EletronicECommerce.UseCase.Exceptions;
using EletronicECommerce.UseCase.Implementation.Builders;
using EletronicECommerce.UseCase.Implementation.UseCase;
using EletronicECommerce.UseCase.Interfaces.Repositories;
using Moq;
using Xunit;

namespace EletronicECommerce.UnitTest.UseCase
{
    public class RegisterCustomerUseCaseTest
    {
        private readonly RegisterCustomerUseCase _registerCustomerUseCase;
        private readonly Mock<ICustomerRepository> _customerRepository;

        public RegisterCustomerUseCaseTest()
        {
            _customerRepository = new Mock<ICustomerRepository>();
            var createCustomerBuilder = new CreateCustomerBuilder(_customerRepository.Object); 
            _registerCustomerUseCase = new RegisterCustomerUseCase(createCustomerBuilder);
        }

        [Fact]
        public void MustHaveAValidCustomerToBeCreated()
        {
            var customer = CreateNewCustomer("11122244455");

            var result = _registerCustomerUseCase.Create(customer);

            Assert.True(result.Identifier != Guid.Empty);
        }

        [Theory]
        [InlineData("1112224445")]
        [InlineData("111222444555777")]
        public void IfDocumentNumberIsNotBetweenElevenAndFourteenCharactersShouldThrowADomainException(string number)
        {   
            var customer = CreateNewCustomer(number);

            var ex = Assert.Throws<DomainException>(() => _registerCustomerUseCase.Create(customer));

            Assert.Equal("The document number must be between 11 and 14 chacacters long.", ex.Message);
        }       

        [Fact]
        public void IfThereIsADocumentNumberRegisteredShouldThrowAnUseCaseException()
        {
            _customerRepository
                .Setup(x => x.GetByDocumentNumber(It.IsAny<string>()))
                .Returns(CreateNewCustomer("11111111111"));

            var customer = CreateNewCustomer("11111111111");

            var ex = Assert.Throws<UseCaseException>(() => _registerCustomerUseCase.Create(customer));

            Assert.Equal("This document number 11111111111 is registered.", ex.Message);
        }

        private Customer CreateNewCustomer(string document) => 
            new Customer(
                new Name("Robert", "DelValle"),
                new Document(document, Domain.Entities.Enums.DocumentType.CPF),
                new Address("Jhon boyd dunlop street", "123", "new life", "Campinas", "SP", "Brazil"),
                new Address("Jhon boyd dunlop street", "123", "new life", "Campinas", "SP", "Brazil")
            );
                     
    }
}