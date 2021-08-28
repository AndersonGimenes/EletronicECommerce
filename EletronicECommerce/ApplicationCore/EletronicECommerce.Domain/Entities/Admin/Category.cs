using System;

namespace EletronicECommerce.Domain.Entities.Admin
{
    public class Category : EntityBase
    {
        // Constructor used for automapper
        // TODO : Refactor for update
        public Category()
            : base(Guid.Empty)
        {
            
        }

        // Constructor used for testing
        public Category(string name, Guid guid)
            : base(guid)
        {
            Name = name;
        }       

        public string Name { get; private set; }          
    }
}