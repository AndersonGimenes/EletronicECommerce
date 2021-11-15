using System.IO;
using EletronicECommerce.Infrastructure.Config;
using EletronicECommerce.Infrastructure.Security;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace EletronicECommerce.UnitTest.Infrastructure
{
    public class PasswordHandlerTest
    {
        
        public PasswordHandlerTest()
        {  
            new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile(@"appsettings.test.json", false, false)
               .AddEnvironmentVariables()
               .Build()
               .SetValues();
        }

        [Fact]
        public void VerifyIfThePasswordWasSuccessfullyEncrypt()
        {
            var password = "my_secret_pass";

            var passwordEncrypted = PasswordHandler.EncryptPassword(password);
        
            Assert.Equal("pkfdz5w/sJeVYha6U5WJGg==", passwordEncrypted);

        }

        [Fact]
        public void VerifyIfThePasswordWasSuccessfullyDecrypt()
        {
            var passwordEncrypted = "pkfdz5w/sJeVYha6U5WJGg==";

            var passwordDecrypted = PasswordHandler.DecryptPassword(passwordEncrypted);
        
            Assert.Equal("my_secret_pass", passwordDecrypted);
        
        }
    }
}