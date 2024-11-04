using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dierentuin.Models
{
    public class Category
    {
        public int Id { get; set; }                 // Unique identifier

        [Required]
        public string Name { get; set; }            // Name of the category (e.g., Mammals, Birds)

        public List<Animal> Animals { get; set; } = new List<Animal>(); // List of animals that belong to this category
    }
}
