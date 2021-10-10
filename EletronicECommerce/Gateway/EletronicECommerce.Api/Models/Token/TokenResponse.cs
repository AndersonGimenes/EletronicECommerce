namespace EletronicECommerce.Api.Models.Token
{
    public class TokenResponse
    {
        public TokenResponse(string token)
        {
            Token = token;
        }
        public string Token { get; }
    }
}