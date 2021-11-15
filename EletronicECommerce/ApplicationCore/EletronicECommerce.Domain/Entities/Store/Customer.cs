using System;
using EletronicECommerce.Domain.Entities.ValeuObjects;

namespace EletronicECommerce.Domain.Entities.Store
{
    public class Customer : EntityBase
    {
        public Customer()
            : base(Guid.Empty)
        {
            
        }
        
        public Name FullName { get; private set; }
        public Document Document { get; private set; }
        public Address BillingAddress { get; private set; }
        public Address DeliveryAddess { get; private set; }
        public Guid User { get; private set; }
    }
}