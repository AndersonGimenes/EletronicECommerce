using System;

namespace EletronicECommerce.Domain.Entities
{
    public abstract class EntityBase
    {
        public EntityBase()
        {
            Identifier = Guid.NewGuid();
        }
        public Guid Identifier { get; private set; }
    }
}