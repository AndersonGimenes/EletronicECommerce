namespace EletronicECommerce.Api.Models.User
{
    public class UserResponse
    {
        public UserResponse(string email)
        {
            Email = email;
            Message = "User success, please login";
        }
        public string Email { get; }
        public string Message { get; }
    }
}