using System;

namespace EletronicECommerce.Domain.Entities.Shared
{
    public class User : EntityBase
    {
        // Constructor used for automapper
        // TODO : Refactor for update
        public User()
            : base(Guid.Empty)
        {
            
        }

        // Constructor used for testing
        public User(string email, string password, Guid guid)
            : base(guid)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; private set; }
        public string Password { get; private set; }             
    }
}