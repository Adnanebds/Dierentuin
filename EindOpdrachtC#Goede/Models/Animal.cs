using Dierentuin.Models;
using EindOpdrachtC_Goede.Models.Enums;

public class Animal
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public double SpaceRequirement { get; set; }
    public string? Species { get; set; }
    public Size Size { get; set; }
    public DietaryClass Diet { get; set; }
    public ActivityPattern ActivityPattern { get; set; }
    public List<Animal> Prey { get; set; } = new List<Animal>();
    public SecurityLevel SecurityRequirement { get; set; }
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
    public int? EnclosureId { get; set; }
    public Enclosure? Enclosure { get; set; }
}