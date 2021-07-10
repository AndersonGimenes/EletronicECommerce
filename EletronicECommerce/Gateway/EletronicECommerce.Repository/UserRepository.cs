using System;
using EletronicECommerce.Domain.Entities.Shared;
using EletronicECommerce.UseCase.Interfaces.Repositories;

namespace EletronicECommerce.Repository
{
    public class UserRepository : IUserRepository
    {
        public User CheckUser(User user)
        {
            //[TO-DO] Implements the method
            if(user.Email == "test@test.com" && user.Password == "1234")
                return user;

            return null;
        }
        
        public User Create(User entity)
        {
            throw new NotImplementedException();
        }

        public User GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public User GetByIdentifier(Guid identifier)
        {
            throw new NotImplementedException();
        }

        public User GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}