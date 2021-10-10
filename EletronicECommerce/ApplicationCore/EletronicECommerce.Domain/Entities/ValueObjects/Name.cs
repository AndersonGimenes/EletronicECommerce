namespace EletronicECommerce.Domain.Entities.ValeuObjects
{
    public class Name
    {
        // Constructor used for testing
        public Name(string firstName, string surname)
        {
            FirstName = firstName;
            Surname = surname;
        }

        public string FirstName { get; private set; }
        public string Surname { get; private set; }
    }
}