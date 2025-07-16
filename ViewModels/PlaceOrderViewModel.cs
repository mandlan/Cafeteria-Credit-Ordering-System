using Cafeteria_Credit___Ordering_System.Models;

namespace Cafeteria_Credit___Ordering_System.ViewModels
{
    public class PlaceOrderViewModel
    {
        public string EmployeeNumber { get; set; }
        public List<MenuItemOrderDto> MenuItems { get; set; } = new List<MenuItemOrderDto>();
    }
}