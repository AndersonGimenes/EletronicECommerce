namespace EletronicECommerce.Api.Models.User
{
    public class UserRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }

        // [TO-DO]: Apply validation first fail
    }
}