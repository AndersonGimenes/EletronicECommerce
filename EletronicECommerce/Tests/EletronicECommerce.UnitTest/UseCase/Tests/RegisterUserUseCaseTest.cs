using System;
using EletronicECommerce.Domain.Entities.Shared;
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
    public class RegisterUserUseCaseTest
    {
        private readonly Mock<IUserRepository> _userRepository;
        private readonly RegisterUserUseCase _registerUserUseCase;

        public RegisterUserUseCaseTest()
        {
            _userRepository = new Mock<IUserRepository>();
            
            _registerUserUseCase = new RegisterUserUseCase(new CreateUserBuilder(_userRepository.Object), _userRepository.Object);
        }

        [Fact]
        public void MustHaveAValidUserToBeCreated()
        {
            var user = Mock.NewUserInstance("teste@teste.com",  "Abc123@");

            _userRepository
                .Setup(x => x.Create(It.IsAny<User>()))
                .Returns(user);

            var result = _registerUserUseCase.Create(user);

            Assert.True(result.Identifier != Guid.Empty);
        }

        [Fact]
        public void IfTheEmailDoesNotHaveASpecialChacacterShouldThrowADomainException()
        {
            var user = Mock.NewUserInstance("testtest.com", "my_Secret_P@ssword#1234");

            var ex = Assert.Throws<DomainException>(() => _registerUserUseCase.Create(user));

            Assert.Equal("Invalid email. Please type @ character.", ex.Message);
        }
        
        [Theory]
        [InlineData("my_secret_Password1234", "Invalid password. Please type any special character.")]
        [InlineData("my_secret_P@ssword", "Invalid password. Please type at least a number.")]
        [InlineData("my_secret_p@ssword#1234", "Invalid password. Please type at least a upperCase letter.")]
        public void IfThePasswordIsNotValidShouldThrowADomainException(string password, string result)
        {
            var user = Mock.NewUserInstance("nd@test.com", password);

            var ex = Assert.Throws<DomainException>(() => _registerUserUseCase.Create(user));

            Assert.Equal(result, ex.Message);
        }

        [Fact]
        public void IfHaveMoreThanOneSameUserShouldThrowAnUseCaseException()
        {
            var user = Mock.NewUserInstance("test@test.com", "my_Secret_P@ssword#1234");

            _userRepository
                .Setup(x => x.GetByEmail(It.IsAny<string>()))
                .Returns(() => user);

            var ex = Assert.Throws<UseCaseException>(() => _registerUserUseCase.Create(user));

            Assert.Equal("Email test@test.com already registered.", ex.Message);
        }
    }
}