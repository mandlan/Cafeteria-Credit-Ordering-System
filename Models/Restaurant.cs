using System.ComponentModel.DataAnnotations;

namespace Cafeteria_Credit___Ordering_System.Models
{
    public class Restaurant
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string LocationDescription { get; set; }

        [Phone]
        public string ContactNumber { get; set; }

        public ICollection<MenuItem> MenuItems { get; set; }
    }
}
