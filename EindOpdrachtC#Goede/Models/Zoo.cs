using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dierentuin.Models
{
    public class Zoo
    {
        public int Id { get; set; }  // Unique identifier for the zoo

        [Required]  // Make Name a required field
        public string Name { get; set; }  // Name of the zoo

        public List<Enclosure> Enclosures { get; set; } = new List<Enclosure>();  // List of enclosures in the zoo

        public List<Animal> Animals { get; set; } = new List<Animal>();  // List of animals in the zoo

        // Additional properties can be added here, e.g.:
        // public string Location { get; set; }
        // public string OpeningHours { get; set; }
    }
}
