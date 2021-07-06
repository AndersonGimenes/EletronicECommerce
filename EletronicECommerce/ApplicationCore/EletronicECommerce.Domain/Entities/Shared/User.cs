namespace EletronicECommerce.Domain.Entities.Shared
{
    public class User : EntityBase
    {
        public User(string email, string passWord)
        {
            Email = email;
            PassWord = passWord;
        }

        public string Email { get; private set; }
        public string PassWord { get; private set; }             
    }
}