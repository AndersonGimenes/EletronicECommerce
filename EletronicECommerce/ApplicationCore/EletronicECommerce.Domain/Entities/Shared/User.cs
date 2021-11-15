using System;
using EletronicECommerce.Domain.Entities.Enums;

namespace EletronicECommerce.Domain.Entities.Shared
{
    public class User : EntityBase
    {
        public User()
            : base(Guid.Empty)
        {
            
        }
        
        public string Email { get; private set; }
        public string Password { get; private set; } 
        public RoleType Role { get; private set; }            
    }
}