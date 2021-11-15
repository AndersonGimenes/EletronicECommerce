using System;

namespace EletronicECommerce.Domain.Entities
{
    public abstract class EntityBase
    {
        protected EntityBase(Guid guid)
        {
            Identifier = guid == Guid.Empty ? Guid.NewGuid() : guid;
        }
        public Guid Identifier { get; private set; }
    }
}