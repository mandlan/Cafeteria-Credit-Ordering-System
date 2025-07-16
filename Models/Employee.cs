using System.ComponentModel.DataAnnotations;

namespace Cafeteria_Credit___Ordering_System.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
       public string EmployeenNumber { get; set; }

        [Required]
       public string Name { get; set; }
        public decimal balance { get; set; }
        public DateTime lastDepositMonth { get; set; }
    }
}
