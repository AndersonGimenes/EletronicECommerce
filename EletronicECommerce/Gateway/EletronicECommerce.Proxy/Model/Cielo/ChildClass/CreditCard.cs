namespace EletronicECommerce.Proxy.Model.Cielo.ChildClass
{
    public class CreditCard
    {
        public string CardNumber { get; private set; }
        public string Holder { get; private set; }
        public string ExpirationDate { get; private set; }
        public string SecurityCode { get; private set; }
        public string Brand { get; private set; }
    }
}