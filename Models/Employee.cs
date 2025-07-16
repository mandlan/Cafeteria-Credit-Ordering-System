using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string IdentityUserId { get; set; } // Foreign key for Identity User

  
        public IdentityUser IdentityUser { get; set; } // Navigation property for Identity User
        public ICollection<Order> Orders { get; set; }

    }
}
