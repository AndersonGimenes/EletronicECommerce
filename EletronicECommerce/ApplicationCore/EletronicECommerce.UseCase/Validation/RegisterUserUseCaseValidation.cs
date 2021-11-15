using EletronicECommerce.Domain.Entities.Shared;
using EletronicECommerce.UseCase.Exceptions;
using EletronicECommerce.UseCase.Interfaces.Repositories;

namespace EletronicECommerce.UseCase.Validation
{
    internal static class RegisterUserUseCaseValidation
    {
        internal static void Validate(User user, IUserRepository userRepository)
        {
            var userDto = userRepository.GetByEmail(user.Email);

            if(userDto != null)
                throw new UseCaseException($"Email {user.Email} already registered.");
        }
    }
}