using EletronicECommerce.Domain.Entities.Shared;
using EletronicECommerce.UseCase.Interfaces.Builder;
using EletronicECommerce.UseCase.Interfaces.Repositories;
using EletronicECommerce.Domain.Validation;
using EletronicECommerce.UseCase.Validation;

namespace EletronicECommerce.UseCase.Implementation.Builder
{
    public class CreateUserBuilder : ICreateUserBuilder
    {
        private readonly IUserRepository _userRepository;
        private User _user;

        public CreateUserBuilder(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User CallRepository() =>
            _userRepository.Create(_user);
        
        public IBuilder<User> Set(User user)
        {
            _user = user;
            return this;
        }

        public IBuilder<User> Validate()
        {
            _user.Validate();
            RegisterUserUseCaseValidation.Validate(_user, _userRepository);
            
            return this;
        }
    }
}