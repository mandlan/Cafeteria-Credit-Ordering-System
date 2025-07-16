using Cafeteria_Credit___Ordering_System.Models;

namespace Cafeteria_Credit___Ordering_System.ViewModels
{
    public class DashboardViewModel
    {
        // For employees
        public string EmployeeName { get; set; }
        public decimal Balance { get; set; }
        public List<Order> RecentOrders { get; set; }

        // For admins
        public int TotalEmployees { get; set; }
        public List<Order> PendingOrders { get; set; }

    }
}
