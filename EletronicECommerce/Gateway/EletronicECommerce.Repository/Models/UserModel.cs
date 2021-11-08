namespace EletronicECommerce.Repository.Models
{
    public class UserModel : BaseModel
    {
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }

        internal void SetPassword(string password)
        {
            Password = password;
        }
    }
}