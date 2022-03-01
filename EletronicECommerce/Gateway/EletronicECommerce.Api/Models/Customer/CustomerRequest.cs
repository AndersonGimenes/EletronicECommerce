using System;
using System.Collections.Generic;

namespace EletronicECommerce.Api.Models.Customer
{
    public class CustomerRequest
    {
        public Name FullName { get; set; }
        public Document Document { get; set; }
        public IEnumerable<Address> Addresses { get; set; }
        public Guid UserIdentifier { get; set; }        
    }
}