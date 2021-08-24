namespace EletronicECommerce.Domain.Entities.Shared
{
    public class User : EntityBase
    {
        public User(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; private set; }
        public string Password { get; private set; }             
    }
}