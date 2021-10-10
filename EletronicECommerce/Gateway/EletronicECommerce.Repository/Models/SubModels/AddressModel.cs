using System;

namespace EletronicECommerce.Repository.Models.SubModels
{
    public class AddressModel
    {
        public int Id { get; private set; } 
        public string Street {get; private set; }
        public string Number {get; private set; }
        public string Neighborhood { get; private set; } 
        public string City { get; private set; }
        public string State { get; private set; }     
        public string Country { get; private set; }
        public string AddressType { get; set; }
        public Guid Customer { get; private set; }

        internal void SetCustumer(Guid customer)
        {
            this.Customer = customer;
        }

        internal void SetAddressType(string addressType)
        {
            this.AddressType = addressType;
        }
    }
}