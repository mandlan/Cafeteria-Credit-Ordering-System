namespace Cafeteria_Credit___Ordering_System.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; } // Foreign key to the order
        public int MenuItemId { get; set; } // Foreign key to the menu item
        public int Quantity { get; set; } 
        public decimal Price { get; set; } // Price of the menu item at the time of order
    }
}
