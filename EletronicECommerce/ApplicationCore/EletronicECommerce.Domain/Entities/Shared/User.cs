using System;

namespace EletronicECommerce.Domain.Entities.Shared
{
    public class User : EntityBase
    {
        public User(string email, string password, Guid guid)
            : base(guid)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; }
        public string Password { get; }             
    }
}