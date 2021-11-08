namespace EletronicECommerce.Proxy.Model.Cielo.ChildClass
{
    public class Payment
    {
        public string Type { get; private set; }     
        public int Amount { get; private set; }
        public int Installments { get; private set; }
        public CreditCard CreditCard { get; private set; }

    }
}