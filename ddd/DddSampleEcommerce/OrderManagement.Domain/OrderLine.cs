namespace OrderManagement.Domain
{
    public class OrderLine
    {
        public Product Product { get; }
        public int Quantity { get; }
        public decimal UnitPrice { get; }

        private OrderLine(Product product, int quantity, decimal unitPrice)
        {
            Product = product;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public static OrderLine Create(Product product, int quantity, decimal unitPrice)
        {
            return new OrderLine(product, quantity, unitPrice);
        }
    }
}
