using System;
using EletronicECommerce.Domain.Entities.ValeuObjects;

namespace EletronicECommerce.Domain.Entities.Store
{
    public class Customer : EntityBase
    {
        public Customer(Name fullName, Document document, Address billingAddress, Address deliveryAddess, Guid user, Guid guid)
            : base(guid)
        {
            FullName = fullName;
            Document = document;
            BillingAddress = billingAddress;
            DeliveryAddess = deliveryAddess;
            User = user;
        }
        
        public Name FullName { get; }
        public Document Document { get; }
        public Address BillingAddress { get; }
        public Address DeliveryAddess { get; }
        public Guid User { get; }
    }
}