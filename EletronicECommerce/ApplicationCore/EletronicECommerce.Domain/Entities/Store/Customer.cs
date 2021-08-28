using System;
using EletronicECommerce.Domain.Entities.ValeuObjects;

namespace EletronicECommerce.Domain.Entities.Store
{
    public class Customer : EntityBase
    {
        // Constructor used for automapper
        // TODO : Refactor for update
        public Customer()
            : base(Guid.Empty)
        {
            
        }

        // Constructor used for testing
        public Customer(Name fullName, Document document, Address billingAddress, Address deliveryAddess, Guid user, Guid guid)
            : base(guid)
        {
            FullName = fullName;
            Document = document;
            BillingAddress = billingAddress;
            DeliveryAddess = deliveryAddess;
            User = user;
        }
        
        public Name FullName { get; private set; }
        public Document Document { get; private set; }
        public Address BillingAddress { get; private set; }
        public Address DeliveryAddess { get; private set; }
        public Guid User { get; private set; }
    }
}