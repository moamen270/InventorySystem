namespace Models.Entities
{
    public class StockHistory
    {
        public int Id { get; set; }
        public int QuantityChange { get; set; }
        public DateTime ChangeDate { get; set; }
        public string Reason { get; set; }

        // Foreign key to Product
        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}