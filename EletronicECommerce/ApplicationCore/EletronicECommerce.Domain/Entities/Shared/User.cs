using System;
using EletronicECommerce.Domain.Entities.Enums;

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
        public User(string email, string password, Guid guid, RoleType role)
            : base(guid)
        {
            Email = email;
            Password = password;
            Role = role;
        }

        public string Email { get; private set; }
        public string Password { get; private set; } 
        public RoleType Role { get; private set; }            
    }
}