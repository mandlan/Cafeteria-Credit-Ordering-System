﻿namespace Cafeteria_Credit___Ordering_System.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LocationDescription { get; set; }
        public string ContactNumber { get; set; }

        public ICollection<MenuItem> MenuItems { get; set; }
    }
}
