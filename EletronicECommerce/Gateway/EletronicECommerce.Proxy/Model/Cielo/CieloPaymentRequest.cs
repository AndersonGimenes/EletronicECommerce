using EletronicECommerce.Proxy.Model.Cielo.ChildClass;

namespace EletronicECommerce.Proxy.Model.Cielo
{
    public class CieloPaymentRequest
    {
        public string MerchantOrderId { get; private set; } 
        public Customer Customer { get; private set; }    
        public Payment Payment { get; private set; }       
        public bool IsCustomerBillPaymentService { get; private set; }       

    }
}