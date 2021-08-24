using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using EletronicECommerce.Infrastructure.Config;

namespace EletronicECommerce.Infrastructure.Security
{
    public static class PasswordHandler
    {
        // When saving call this method to encrypt the password.
        public static string EncryptPassword(string password)
        {
            var resultArray = CreateMD5Object(password, "CreateEncryptor", () => UTF8Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        // When validating the password use this method to decrypt one.
        public static string DecryptPassword(string password)
        {
            var resultArray = CreateMD5Object(password, "CreateDecryptor", () => Convert.FromBase64String(password));            
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        private static byte[] CreateMD5Object(string password, string methodName, Func<dynamic> action)
        {
            var objMD5CryptoService = new MD5CryptoServiceProvider();
            var objTripleDESCryptoService = new TripleDESCryptoServiceProvider();            

            var toEncryptArray = action.Invoke();            

            var securityKeyArray = objMD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(Settings.SecurityPasswordKey));
            objMD5CryptoService.Clear();

            objTripleDESCryptoService.Key = securityKeyArray;
            objTripleDESCryptoService.Mode = CipherMode.ECB;
            objTripleDESCryptoService.Padding = PaddingMode.PKCS7;

            var objCrytpoTransform = objTripleDESCryptoService
                                            .GetType()
                                            .GetMethods()
                                            .First(x => x.Name == methodName)
                                            .Invoke(objTripleDESCryptoService, null) as ICryptoTransform;

            objTripleDESCryptoService.Clear();
                                                
            return objCrytpoTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
        }
    }
}