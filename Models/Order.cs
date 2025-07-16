namespace Cafeteria_Credit___Ordering_System.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; }   
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
