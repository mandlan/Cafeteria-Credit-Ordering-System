namespace Cafeteria_Credit___Ordering_System.ViewModels
{
    public class MenuItemOrderDto
    {
        public int MenuItemId { get; set; } // Foreign key to the menu item
        public string Name { get; set; } // Name of the menu item
        public decimal Price { get; set; } // Price of the menu item
        public int Quantity { get; set; } // Quantity of the menu item ordered
        public decimal TotalPrice => Price * Quantity; // Total price for this order item   
    }
}
