namespace EletronicECommerce.Domain.Entities.Admin
{
    public class Product : EntityBase
    {
        public string Name { get; private set; }
        public string Code { get; private set; }
        public decimal PurchasePrice { get; private set; }
        public decimal SalePrice { get; private set; }
        public int Quantity { get; private set; }

        public Product(string name, string code, decimal purchasePrice, decimal salePrice, int quantity)
        {
            Name = name;
            Code = code;
            PurchasePrice = purchasePrice;
            SalePrice = salePrice;
            Quantity = quantity;
        }
    }
}