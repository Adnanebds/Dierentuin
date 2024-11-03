using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EindOpdrachtC_Goede.Models;

using EindOpdrachtC_Goede.Models.Enums;
public class Enclosure
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public List<Animal> Animals { get; set; } = new List<Animal>();

    public double Size { get; set; }
    public Climate Climate { get; set; }
    public SecurityLevel SecurityLevel { get; set; }
    public HabitatType HabitatType { get; set; }
}
