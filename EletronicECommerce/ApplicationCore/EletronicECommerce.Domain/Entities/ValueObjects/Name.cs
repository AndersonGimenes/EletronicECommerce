namespace EletronicECommerce.Domain.Entities.ValeuObjects
{
    public class Name
    {
        public Name(string firstName, string surname)
        {
            FirstName = firstName;
            Surname = surname;
        }

        public string FirstName { get; }
        public string Surname { get; }
    }
}