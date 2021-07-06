using EletronicECommerce.Domain.Entities.Shared;

namespace EletronicECommerce.UseCase.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetByEmail(string email);
    }
}