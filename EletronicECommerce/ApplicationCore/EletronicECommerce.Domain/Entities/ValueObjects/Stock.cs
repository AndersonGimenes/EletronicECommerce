namespace EletronicECommerce.Domain.Entities.ValeuObjects
{
    public class Stock
    {        
        public Stock(decimal purchasePrice, int quantity)
        {
            PurchasePrice = purchasePrice;
            Quantity = quantity;
        }
        public decimal PurchasePrice { get; private set; }
        public int Quantity { get; private set; }
    }
}