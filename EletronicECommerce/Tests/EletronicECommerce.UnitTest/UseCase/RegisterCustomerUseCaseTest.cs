using System;
using EletronicECommerce.Domain.Entities.Shared;
using EletronicECommerce.Domain.Entities.Store;
using EletronicECommerce.Domain.Entities.ValeuObjects;
using EletronicECommerce.Domain.Exceptions;
using EletronicECommerce.UseCase.Exceptions;
using EletronicECommerce.UseCase.Implementation.Builder;
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
        private readonly Mock<IUserRepository> _userRepository;

        public RegisterCustomerUseCaseTest()
        {
            _customerRepository = new Mock<ICustomerRepository>();
            _userRepository = new Mock<IUserRepository>();

            _registerCustomerUseCase = new RegisterCustomerUseCase(new CreateCustomerBuilder(_customerRepository.Object, _userRepository.Object));
        }

        [Fact]
        public void MustHaveAValidCustomerToBeCreated()
        {
            var userGuid = Guid.NewGuid();

            _userRepository
                .Setup(x => x.GetByIdentifier(It.IsAny<Guid>()))
                .Returns(new User("teste@teste.com", "Abc123@", userGuid));

            var customer = CreateNewCustomer("11122244455", userGuid);
            var result = _registerCustomerUseCase.Create(customer);

            Assert.True(result.Identifier != Guid.Empty);
        }

        [Theory]
        [InlineData("1112224445")]
        [InlineData("111222444555777")]
        public void IfDocumentNumberIsNotBetweenElevenAndFourteenCharactersShouldThrowADomainException(string number)
        {   
            var customer = CreateNewCustomer(number, Guid.NewGuid());

            var ex = Assert.Throws<DomainException>(() => _registerCustomerUseCase.Create(customer));

            Assert.Equal("The document number must be between 11 and 14 chacacters long.", ex.Message);
        }       

        [Fact]
        public void IfThereIsADocumentNumberRegisteredShouldThrowAnUseCaseException()
        {
            var userGuid = Guid.NewGuid();

            _customerRepository
                .Setup(x => x.GetByDocumentNumber(It.IsAny<string>()))
                .Returns(CreateNewCustomer("11111111111", Guid.NewGuid()));

            _userRepository
                .Setup(x => x.GetByIdentifier(It.IsAny<Guid>()))
                .Returns(new User("teste@teste.com", "Abc123@", userGuid));

            var customer = CreateNewCustomer("11111111111", userGuid);

            var ex = Assert.Throws<UseCaseException>(() => _registerCustomerUseCase.Create(customer));

            Assert.Equal("This document number 11111111111 is registered.", ex.Message);
        }

        [Fact]
        public void IfThereIsAUserLinkedWithAnotherCustomerShouldThrowAnUseCaseException()
        {
            var userGuid = Guid.NewGuid();

            _customerRepository
                .Setup(x => x.GetByUserIdentifier(It.IsAny<Guid>()))
                .Returns(CreateNewCustomer("11111111111", userGuid));

            var customer = CreateNewCustomer("11111111111", userGuid);

            var ex = Assert.Throws<UseCaseException>(() => _registerCustomerUseCase.Create(customer));

            Assert.Equal("There is already a record linked to this user.", ex.Message);
        }

        [Fact]
        public void IfThereIsNotAUserShouldThrowAnUseCaseException()
        {
            var userGuid = Guid.NewGuid();

            var customer = CreateNewCustomer("11111111111", userGuid);

            var ex = Assert.Throws<UseCaseException>(() => _registerCustomerUseCase.Create(customer));

            Assert.Equal("Must enter a valid user.", ex.Message);
        }

        private Customer CreateNewCustomer(string document, Guid user) => 
            new Customer(
                new Name("Robert", "DelValle"),
                new Document(document, Domain.Entities.Enums.DocumentType.CPF),
                new Address("Jhon boyd dunlop street", "123", "new life", "Campinas", "SP", "Brazil"),
                new Address("Jhon boyd dunlop street", "123", "new life", "Campinas", "SP", "Brazil"),
                user,
                Guid.Empty
            );         
    }
}