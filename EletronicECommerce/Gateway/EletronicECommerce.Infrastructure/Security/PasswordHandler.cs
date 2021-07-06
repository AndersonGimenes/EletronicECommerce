using System;
using System.Security.Cryptography;
using System.Text;

namespace EletronicECommerce.Infrastructure.Security
{
    public static class PasswordHandler
    {
        // When saving call this method to encrypt the password.
        public static string EncryptPassword(string password)
        {
            var objMD5CryptoService = new MD5CryptoServiceProvider();
            var objTripleDESCryptoService = new TripleDESCryptoServiceProvider();

            var toEncryptedArray = UTF8Encoding.UTF8.GetBytes(password);

            var securityKeyArray = objMD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(Config.Config.SecurityPasswordKey));
            objMD5CryptoService.Clear();
            
            objTripleDESCryptoService.Key = securityKeyArray;            
            objTripleDESCryptoService.Mode = CipherMode.ECB;
            objTripleDESCryptoService.Padding = PaddingMode.PKCS7;

            var objCrytpoTransform = objTripleDESCryptoService.CreateEncryptor();
            
            var resultArray = objCrytpoTransform.TransformFinalBlock(toEncryptedArray, 0, toEncryptedArray.Length);
            objTripleDESCryptoService.Clear();

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        // When validating the password use this method to decrypt one.
        public static string DecryptPassword(string password)
        {
            var objMD5CryptoService = new MD5CryptoServiceProvider();
            var objTripleDESCryptoService = new TripleDESCryptoServiceProvider();            

            var toEncryptArray = Convert.FromBase64String(password);            

            var securityKeyArray = objMD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(Config.Config.SecurityPasswordKey));
            objMD5CryptoService.Clear();

            objTripleDESCryptoService.Key = securityKeyArray;
            objTripleDESCryptoService.Mode = CipherMode.ECB;
            objTripleDESCryptoService.Padding = PaddingMode.PKCS7;

            var objCrytpoTransform = objTripleDESCryptoService.CreateDecryptor();
            
            var resultArray = objCrytpoTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            objTripleDESCryptoService.Clear();

            return UTF8Encoding.UTF8.GetString(resultArray);
        }
    }
}