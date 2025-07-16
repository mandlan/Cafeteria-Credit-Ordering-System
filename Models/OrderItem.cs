﻿namespace Cafeteria_Credit___Ordering_System.Models
{
    public class OrderItem
    {
        public int Id { get; set; } 
        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int OrderId { get; set; } 
    }
}
