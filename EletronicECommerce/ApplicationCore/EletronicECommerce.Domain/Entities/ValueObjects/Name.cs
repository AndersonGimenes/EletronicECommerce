namespace EletronicECommerce.Domain.Entities.ValeuObjects
{
    public class Name
    {
        public string FirstName { get; private set; }
        public string Surname { get; private set; }

        public Name(string firstName, string surname)
        {
            FirstName = firstName;
            Surname = surname;
        }
    }
}