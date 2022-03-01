using System;
using System.Collections.Generic;
using EletronicECommerce.Domain.Entities.Enums;

namespace EletronicECommerce.Domain.Entities.Store
{
    public class Order : EntityBase
    {
        public Order() 
            : base(Guid.Empty)
        {
        }

        public Guid User { get; private set; }
        public IEnumerable<Guid> Products { get; private set; }
        public StatusOrder StatusOrder{get; private set;}
        public TypePayment TypePayment { get; private set; }
    }
}