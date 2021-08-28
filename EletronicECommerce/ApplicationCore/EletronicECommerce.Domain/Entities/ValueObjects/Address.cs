namespace EletronicECommerce.Domain.Entities.ValeuObjects
{
    public class Address
    {
        public Address(string street, string number, string neighborhood, string city, string state, string country)
        {
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Country = country;
        }

        public string Street {get; }
        public string Number {get; }
        public string Neighborhood { get; } 
        public string City { get; }
        public string State { get; }     
        public string Country { get; }
    }
}