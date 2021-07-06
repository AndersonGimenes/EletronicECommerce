using EletronicECommerce.Infrastructure.Security;
using Xunit;

namespace EletronicECommerce.UnitTest.Infrastructure
{
    public class PasswordHandlerTest
    {
        [Fact]
        public void VerifyIfThePasswordWasSuccessfullyEncrypt()
        {
            var password = "my_secret_pass";

            var passwordEncrypted = PasswordHandler.EncryptPassword(password);
        
            Assert.NotEqual(password, passwordEncrypted);

        }

        [Fact]
        public void VerifyIfThePasswordWasSuccessfullyDecrypt()
        {
            var passwordEncrypted = "TwefhcnB56R45a+RgLqivg==";

            var passwordDecrypted = PasswordHandler.DecryptPassword(passwordEncrypted);
        
            Assert.NotEqual(passwordEncrypted, passwordDecrypted);
        
        }

        [Fact]
        public void VerifyTheSamePasswordWasSuccessfullyEncryptAndDecrypt()
        {
            var originalPassword = "my_secret_pass";

            var passwordEncrypted = PasswordHandler.EncryptPassword(originalPassword);
            var passwordDecrypted = PasswordHandler.DecryptPassword(passwordEncrypted);
        
            Assert.Equal(originalPassword, passwordDecrypted);
        }
    }
}