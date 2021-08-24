using System.Text;
using System.Text.RegularExpressions;
using EletronicECommerce.Domain.Entities.Shared;
using EletronicECommerce.Domain.Exceptions;

namespace EletronicECommerce.Domain.Validation
{
    public static class UserValidation
    {
        public static void IsValid(this User user)
        {
            var stringBuilder = new StringBuilder();

            if(!user.Email.Contains("@"))
                stringBuilder.Append("Invalid email. Please type @ character.");

            if(!HasSymbol(user.Password))
                stringBuilder.Append("Invalid password. Please type any special character.");

            if(!HasDigit(user.Password))
                stringBuilder.Append("Invalid password. Please type at least a number.");
            
            if(!HasLetter(user.Password))
                stringBuilder.Append("Invalid password. Please type at least a upperCase letter.");

            if(stringBuilder.Length > 0)
                throw new DomainException(stringBuilder.ToString());
        }

        private static bool HasLetter(string str)
        {
            var pattern = "[A-Z]";
            var regex = new Regex(pattern);

            return regex.IsMatch(str);
        }
        
        private static bool HasDigit(string str)
        {
            var pattern = "[0-9]";
            var regex = new Regex(pattern);

            return regex.IsMatch(str);
        }

        private static bool HasSymbol(string str) 
        {
            var pattern = "[!@#$%^&*(),.?\":{}|<>]";
            var regex = new Regex(pattern);

            return regex.IsMatch(str);
        }
        
    }
}