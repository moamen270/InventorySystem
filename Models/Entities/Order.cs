using Models.Enums;

namespace Models.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public Status Status { get; set; }
        public decimal TotalAmount { get; set; }

        // Foreign key to Customer
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        // Navigation property for OrderItems
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}