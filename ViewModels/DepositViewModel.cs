using System.ComponentModel.DataAnnotations;

namespace Cafeteria_Credit___Ordering_System.ViewModels
{
    public class DepositViewModel
    {
        [Required]
        [Display(Name = "Employee Number")]
        public string EmployeeNumber { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Deposit amount must be greater than zero.")]
        [Display(Name = "Deposit Amount (R)")]
        public decimal DepositAmount { get; set; }

    }
}
