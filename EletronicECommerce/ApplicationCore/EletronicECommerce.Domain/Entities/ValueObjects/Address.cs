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

        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; } 
        public string City { get; private set; }
        public string State { get; private set; }     
        public string Country { get; private set; }
    }
}