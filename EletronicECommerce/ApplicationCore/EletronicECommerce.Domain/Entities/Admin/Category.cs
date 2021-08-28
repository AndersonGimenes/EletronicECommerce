using System;

namespace EletronicECommerce.Domain.Entities.Admin
{
    public class Category : EntityBase
    {
        public Category(string name, Guid guid)
            : base(guid)
        {
            Name = name;
        }       

        public string Name { get; }          
    }
}