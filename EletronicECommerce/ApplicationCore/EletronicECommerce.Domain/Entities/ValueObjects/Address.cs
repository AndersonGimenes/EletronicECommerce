using EletronicECommerce.Domain.Entities.Enums;

namespace EletronicECommerce.Domain.Entities.ValeuObjects
{
    public class Address
    {
        public string Street {get; private set; }
        public string Number {get; private set; }
        public string Neighborhood { get; private set; } 
        public string City { get; private set; }
        public string State { get; private set; }     
        public string Country { get; private set; }
        public AddressType AddressType { get; private set; }
    }
}