using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EindOpdrachtC_Goede.Models
{
    public class Zoo
    {
        public int Id { get; set; }                           // Unique identifier for the zoo

        [Required]                                           // Make Name a required field
        public string Name { get; set; }                     // Name of the zoo

        public List<Enclosure> Enclosures { get; set; } = new List<Enclosure>(); // List of enclosures in the zoo

        // You might add other properties here, e.g.,
        // public string Location { get; set; }
        // public string OpeningHours { get; set; }
    }
}
