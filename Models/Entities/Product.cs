﻿namespace Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int ReorderLevel { get; set; }

        // Foreign key to Supplier
        public int SupplierId { get; set; }

        public Supplier Supplier { get; set; }

        // Navigation property for OrderItems
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}