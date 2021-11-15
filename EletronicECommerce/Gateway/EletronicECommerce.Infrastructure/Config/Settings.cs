using Microsoft.Extensions.Configuration;

namespace EletronicECommerce.Infrastructure.Config
{
    static public class Settings
    {
        internal static string SecurityPasswordKey {get; private set;}
        public static string SecurityTokenKey {get; private set;}
        public static string Issuer {get; private set;}
        public static string ConnectionString {get; private set;}
        public static string UriBaseCielo {get; private set;}
        public static string MerchantId {get; private set;}
        public static string MerchantKey {get; private set;}

        public static void SetValues(this IConfiguration config)
        {
            SecurityPasswordKey = config.GetValue<string>("Security:SecurityPasswordKey");
            SecurityTokenKey = config.GetValue<string>("Security:SecurityTokenKey");
            ConnectionString = config.GetValue<string>("ConnectionStrings:Default");
            Issuer = config.GetValue<string>("Identity:Issuer");
            UriBaseCielo = config.GetValue<string>("CieloKeys:UriBaseCielo");
            MerchantId = config.GetValue<string>("CieloKeys:MerchantId");
            MerchantKey = config.GetValue<string>("CieloKeys:MerchantKey");
        }        
    }
}