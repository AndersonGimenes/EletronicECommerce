namespace EletronicECommerce.Repository.Models
{
    public class UserModel : BaseModel
    {
        public string Email { get; private set; }
        public string Password { get; private set; }

        internal UserModel SetPassword(string password)
        {
            Password = password;
            return this;
        }
    }
}