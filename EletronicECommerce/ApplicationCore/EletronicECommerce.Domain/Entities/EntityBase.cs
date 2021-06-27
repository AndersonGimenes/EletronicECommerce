using System;

namespace EletronicECommerce.Domain.Entities
{
    public abstract class EntityBase
    {
        public Guid Identifier { get; private set; }

        public EntityBase()
        {
            Identifier = Guid.NewGuid();
        }
    }
}