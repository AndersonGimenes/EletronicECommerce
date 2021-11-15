using System;

namespace EletronicECommerce.Domain.Entities.Admin
{
    public class Category : EntityBase
    {
        public Category()
            : base(Guid.Empty)
        {
            
        }
        
        public string Name { get; private set; }          
    }
}