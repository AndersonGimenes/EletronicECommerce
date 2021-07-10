using EletronicECommerce.Domain.Entities.Shared;
using EletronicECommerce.UseCase.Interfaces.Builder;
using EletronicECommerce.UseCase.Interfaces.Repositories;
using EletronicECommerce.UseCase.Interfaces.UseCase;

namespace EletronicECommerce.UseCase.Implementation.UseCase
{
    public class RegisterUserUseCase : RegisterBaseUseCase<User>, IRegisterUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserUseCase(ICreateUserBuilder createUserBuilder, IUserRepository userRepository) 
            : base(createUserBuilder)
        {
            _userRepository = userRepository;
        }

        public User CheckUser(User user) => _userRepository.CheckUser(user);
    }
}