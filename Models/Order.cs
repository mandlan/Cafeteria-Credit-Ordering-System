namespace Cafeteria_Credit___Ordering_System.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; } // Foreign key to the user who placed the order
        public Employee employee { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = "Pending"; // Default status is Pending
        public ICollection<OrderItem> orderItems { get; set; }
        
        }
}
