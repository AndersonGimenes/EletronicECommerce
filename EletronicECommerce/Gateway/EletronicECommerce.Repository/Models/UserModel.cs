namespace EletronicECommerce.Repository.Models
{
    internal class UserModel : BaseModel
    {
        internal string Email { get; private set; }
        internal string Password { get; private set; }
    }
}