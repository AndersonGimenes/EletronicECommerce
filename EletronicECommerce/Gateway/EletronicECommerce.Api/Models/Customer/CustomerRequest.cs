using System;

namespace EletronicECommerce.Api.Models.Customer
{
    public class CustomerRequest
    {
        public Name FullName { get; set; }
        public Document Document { get; set; }
        public Address BillingAddress { get; set; }
        public Address DeliveryAddess { get; set; }
        public Guid User { get; set; }        
    }
}