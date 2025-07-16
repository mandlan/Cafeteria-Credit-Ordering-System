using System.ComponentModel.DataAnnotations;

namespace Cafeteria_Credit___Ordering_System.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
       public string EmployeeNumber { get; set; }

        [Required]
       public string Name { get; set; }
        public decimal MonthlyDeposit { get; set; } = 0.00m; // Default value is 0.00
        public decimal balance { get; set; }
        public DateTime lastDepositMonth { get; set; }
    }
}
