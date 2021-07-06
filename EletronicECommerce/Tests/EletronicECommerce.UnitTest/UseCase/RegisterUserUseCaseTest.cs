using System;
using EletronicECommerce.Domain.Entities.Shared;
using EletronicECommerce.Domain.Exceptions;
using EletronicECommerce.UseCase.Exceptions;
using EletronicECommerce.UseCase.Implementation.Builders;
using EletronicECommerce.UseCase.Implementation.UseCase;
using EletronicECommerce.UseCase.Interfaces.Repositories;
using Moq;
using Xunit;

namespace EletronicECommerce.UnitTest.UseCase
{
    public class RegisterUserUseCaseTest
    {
        private readonly Mock<IUserRepository> _userRepository;
        private readonly RegisterUserUseCase _registerUserUseCase;

        public RegisterUserUseCaseTest()
        {
            _userRepository = new Mock<IUserRepository>();
            
            _registerUserUseCase = new RegisterUserUseCase(new CreateUserBuilder(_userRepository.Object));
        }

        [Fact]
        public void MustHaveAValidUserToBeCreated()
        {
            var user = new User("nd@nd.com", "my_Secret_P@ssword#1234");

            var result = _registerUserUseCase.Create(user);

            Assert.True(result.Identifier != Guid.Empty);
        }

        [Fact]
        public void IfTheEmailDoesNotHaveASpecialChacacterShouldThrowADomainException()
        {
            var user = new User("testtest.com", "my_Secret_P@ssword#1234");

            var ex = Assert.Throws<DomainException>(() => _registerUserUseCase.Create(user));

            Assert.Equal("Invalid email. Please type @ character.", ex.Message);
        }
        
        [Theory]
        [InlineData("my_secret_password", "Invalid password. Please type any special character.")]
        [InlineData("my_secret_p@ssword", "Invalid password. Please type at least a number.")]
        [InlineData("my_secret_p@ssword#1234", "Invalid password. Please type at least a upperCase letter.")]
        public void IfThePasswordIsNotValidShouldThrowADomainException(string password, string result)
        {
            var user = new User("nd@test.com", password);

            var ex = Assert.Throws<DomainException>(() => _registerUserUseCase.Create(user));

            Assert.Equal(result, ex.Message);
        }

        [Fact]
        public void IfHaveMoreThanOneSameUserShouldThrowAnUseCaseException()
        {
            _userRepository
                .Setup(x => x.GetByEmail(It.IsAny<string>()))
                .Returns(() => new User("test@test.com", "my_Secret_P@ssword#1234"));

            var user = new User("test@test.com", "my_Secret_P@ssword#1234");

            var ex = Assert.Throws<UseCaseException>(() => _registerUserUseCase.Create(user));

            Assert.Equal("Email test@test.com already registered.", ex.Message);
        }
    }
}