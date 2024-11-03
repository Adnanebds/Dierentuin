using System.ComponentModel.DataAnnotations;

namespace EindOpdrachtC_Goede.Models;

using EindOpdrachtC_Goede.Models.Enums;
public class Animal
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Species { get; set; }

    public int? CategoryId { get; set; }  // Nullable voor als er geen categorie is
    public Category Category { get; set; }

    public double SpaceRequirement { get; set; }
    public SecurityLevel SecurityRequirement { get; set; }
    public DietaryClass DietaryClass { get; set; }
    public ActivityPattern ActivityPattern { get; set; }
}
