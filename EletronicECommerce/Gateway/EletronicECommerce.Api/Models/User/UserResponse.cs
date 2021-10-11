using System;

namespace EletronicECommerce.Api.Models.User
{
    public class UserResponse
    {
        public UserResponse(Guid identifier, string email)
        {
            Identifier = identifier;
            Email = email;
            Message = "User success, please login";
        }
        public Guid Identifier { get; }
        public string Email { get; }
        public string Message { get; }
    }
}