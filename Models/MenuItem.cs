using System.ComponentModel.DataAnnotations;

namespace Cafeteria_Credit___Ordering_System.Models
{
    public class MenuItem
    { 
        public int Id { get; set; }
        public int RestaurantId { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Restaurant Restaurant { get; set; }

    }
}
