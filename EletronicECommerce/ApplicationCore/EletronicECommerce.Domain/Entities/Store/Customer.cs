using EletronicECommerce.Domain.Entities.Vo;

namespace EletronicECommerce.Domain.Entities.Store
{
    public class Customer : EntityBase
    {
        public Name FullName { get; private set; }
        public Document Document { get; private set; }
        public Address BillingAddress { get; private set; }
        public Address DeliveryAddess { get; private set; }

        public Customer(Name fullName, Document document, Address billingAddress, Address deliveryAddess)
        {
            FullName = fullName;
            Document = document;
            BillingAddress = billingAddress;
            DeliveryAddess = deliveryAddess;
        }
    }
}