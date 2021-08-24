namespace EletronicECommerce.Api.Models.User
{
    public class UserResponse
    {
        public UserResponse(string token)
        {
            Token = token;
        }
        public string Token { get; }
    }
}