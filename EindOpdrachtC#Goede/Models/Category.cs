using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EindOpdrachtC_Goede.Models;

public class Category
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public List<Animal> Animals { get; set; } = new List<Animal>();
}
