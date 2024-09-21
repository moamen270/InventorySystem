namespace Models.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }

        // Foreign key to Order
        public int OrderId { get; set; }

        public Order Order { get; set; }

        // Foreign key to Product
        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}