using System;
using System.Collections.Generic;
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
        public IEnumerable<Address> Addresses { get; private set; }
        public Guid UserIdentifier { get; private set; }
    }
}