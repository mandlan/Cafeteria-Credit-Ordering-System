namespace Cafeteria_Credit___Ordering_System.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; } // Foreign key to the user who placed the order
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = "Pending"; // Default status is Pending
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        // Navigation property for the user
        }
}
