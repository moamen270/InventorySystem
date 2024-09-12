namespace Models.Entities
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public string Address { get; set; }

        // Navigation property for Products
        public ICollection<Product> Products { get; set; }
    }
}