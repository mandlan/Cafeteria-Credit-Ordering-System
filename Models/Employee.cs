namespace Cafeteria_Credit___Ordering_System.Models
{
    public class Employee
    {
        public int Id { get; set; }
       public string EmployeenNumber { get; set; }
       public string Name { get; set; }
        public decimal balance { get; set; }
        public DateTime lastDepositMonth { get; set; }
    }
}
