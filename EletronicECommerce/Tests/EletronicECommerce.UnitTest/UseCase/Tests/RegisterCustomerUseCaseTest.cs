using System;
using EletronicECommerce.Domain.Entities.Store;
using EletronicECommerce.Domain.Exceptions;
using EletronicECommerce.UseCase.Exceptions;
using EletronicECommerce.UseCase.Implementation.Builder;
using EletronicECommerce.UseCase.Implementation.UseCase;
using EletronicECommerce.UseCase.Interfaces.Repositories;
using Moq;
using Xunit;
using Mock = EletronicECommerce.UnitTest.UseCase.MockObjects.MockObjects;

namespace EletronicECommerce.UnitTest.UseCase.Tests
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
            var user = Mock.NewUserInstance("teste@teste.com",  "Abc123@");
            var customer = Mock.NewCustomerInstance("11122244455", user.Identifier);

            _userRepository
                .Setup(x => x.GetByIdentifier(It.IsAny<Guid>(), It.IsAny<string>()))
                .Returns(user);

            _customerRepository
                .Setup(x => x.Create(It.IsAny<Customer>()))
                .Returns(customer);

            var result = _registerCustomerUseCase.Create(customer);

            Assert.True(result.Identifier != Guid.Empty);
        }

        [Theory]
        [InlineData("1112224445")]
        [InlineData("111222444555777")]
        public void IfDocumentNumberIsNotBetweenElevenAndFourteenCharactersShouldThrowADomainException(string number)
        {   
            var customer = Mock.NewCustomerInstance(number, Guid.NewGuid());

            var ex = Assert.Throws<DomainException>(() => _registerCustomerUseCase.Create(customer));

            Assert.Equal("The document number must be between 11 and 14 chacacters long.", ex.Message);
        }       

        [Fact]
        public void IfThereIsADocumentNumberRegisteredShouldThrowAnUseCaseException()
        {
            var user = Mock.NewUserInstance("teste@teste.com",  "Abc123@");
            var customer = Mock.NewCustomerInstance("11111111111", user.Identifier);

            _customerRepository
                .Setup(x => x.GetByDocumentNumber(It.IsAny<string>()))
                .Returns(customer);

            _userRepository
                .Setup(x => x.GetByIdentifier(It.IsAny<Guid>(), It.IsAny<string>()))
                .Returns(user);            

            var ex = Assert.Throws<UseCaseException>(() => _registerCustomerUseCase.Create(customer));

            Assert.Equal("This document number 11111111111 is registered.", ex.Message);
        }

        [Fact]
        public void IfThereIsAUserLinkedWithAnotherCustomerShouldThrowAnUseCaseException()
        {
            var userGuid = Guid.NewGuid();
            var customer = Mock.NewCustomerInstance("11111111111", userGuid);

            _customerRepository
                .Setup(x => x.GetByUserIdentifier(It.IsAny<Guid>()))
                .Returns(customer);          

            var ex = Assert.Throws<UseCaseException>(() => _registerCustomerUseCase.Create(customer));

            Assert.Equal("There is already a record linked to this user.", ex.Message);
        }

        [Fact]
        public void IfThereIsNotAUserShouldThrowAnUseCaseException()
        {
            var userGuid = Guid.NewGuid();
            var customer = Mock.NewCustomerInstance("11111111111", userGuid);

            var ex = Assert.Throws<UseCaseException>(() => _registerCustomerUseCase.Create(customer));

            Assert.Equal("Must enter a valid user.", ex.Message);
        }
    }
}