using Models.Enums;

namespace Models.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ShippingAddress { get; set; }
        public Gender Gender { get; set; }

        // Authentication fields
        public string Username { get; set; }

        public string Password { get; set; }

        // Navigation property for Orders
        public ICollection<Order> Orders { get; set; }
    }
}