using System;

namespace EletronicECommerce.Domain.Entities
{
    public abstract class EntityBase
    {
        public EntityBase(Guid guid)
        {
            Identifier = guid == Guid.Empty ? Guid.NewGuid() : guid;
        }
        public Guid Identifier { get; }
    }
}