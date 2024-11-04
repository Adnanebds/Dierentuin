using EindOpdrachtC_Goede.Models.Enums;
using Dierentuin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dierentuin.Controllers
{
    public class ZooController : ControllerBase
    {
        private readonly ZooContext _dbContext; // Database context
        private readonly Zoo _zoo; // Instance of the Zoo model

        public ZooController(ZooContext dbContext, Zoo zoo)
        {
            _dbContext = dbContext; // Initialize the _dbContext
            _zoo = zoo; // Initialize the _zoo instance with the injected Zoo model
        }

        public void Sunrise()
        {
            foreach (var animal in _zoo.Animals)
            {
                if (animal.ActivityPattern == ActivityPattern.Diurnal)
                {
                    Console.WriteLine($"{animal.Name} is wakker geworden.");
                }
                else
                {
                    Console.WriteLine($"{animal.Name} slaapt nog.");
                }
            }
        }

        public void Sunset()
        {
            foreach (var animal in _zoo.Animals)
            {
                if (animal.ActivityPattern == ActivityPattern.Nocturnal)
                {
                    Console.WriteLine($"{animal.Name} is wakker geworden.");
                }
                else if (animal.ActivityPattern == ActivityPattern.Diurnal)
                {
                    Console.WriteLine($"{animal.Name} gaat slapen.");
                }
            }
        }

        public void FeedingTime()
        {
            Random rand = new Random();

            foreach (var animal in _zoo.Animals)
            {
                if (animal.Diet == DietaryClass.Carnivore)
                {
                    var selectedPrey = _zoo.Animals
                        .Where(a => a.Id != animal.Id && a.Size < animal.Size)
                        .FirstOrDefault();

                    if (selectedPrey != null)
                    {
                        Console.WriteLine($"{animal.Name} is aan het eten {selectedPrey.Name}.");
                    }
                    else
                    {
                        Console.WriteLine($"{animal.Name} heeft geen prooi gevonden.");
                    }
                }
                else if (animal.Diet == DietaryClass.Herbivore)
                {
                    List<string> plantFoods = new List<string> { "Grass", "Leaves", "Fruits", "Vegetables" };
                    int randomIndex = rand.Next(plantFoods.Count);
                    string selectedHerb = plantFoods[randomIndex];

                    Console.WriteLine($"{animal.Name} is eating {selectedHerb}.");
                }
                else if (animal.Diet == DietaryClass.Omnivore)
                {
                    if (rand.Next(2) == 0)
                    {
                        List<string> plantFoods = new List<string> { "Grass", "Leaves", "Fruits", "Vegetables" };
                        int randomIndex = rand.Next(plantFoods.Count);
                        string selectedPlantFood = plantFoods[randomIndex];

                        Console.WriteLine($"{animal.Name} is eating {selectedPlantFood}.");
                    }
                    else
                    {
                        var selectedPrey = _zoo.Animals
                            .Where(a => a.Id != animal.Id && a.Size < animal.Size)
                            .FirstOrDefault();

                        if (selectedPrey != null)
                        {
                            Console.WriteLine($"{animal.Name} is eating {selectedPrey.Name}.");
                        }
                        else
                        {
                            Console.WriteLine($"{animal.Name} heeft geen prooi gevonden.");
                        }
                    }
                }
            }
        }

        public void CheckConstraints()
        {
            foreach (var enclosure in _zoo.Enclosures)
            {
                double totalRequiredSpace = enclosure.Animals.Sum(a => a.SpaceRequirement);
                if (totalRequiredSpace > enclosure.Size)
                {
                    Console.WriteLine($"Warning: Enclosure {enclosure.Name} does not have enough space for its animals.");
                }

                foreach (var animal in enclosure.Animals)
                {
                    if (animal.SecurityRequirement > enclosure.SecurityLevel)
                    {
                        Console.WriteLine($"Warning: Enclosure {enclosure.Name} does not meet the security requirements for animal {animal.Name}.");
                    }
                }

                foreach (var predator in enclosure.Animals)
                {
                    foreach (var prey in predator.Prey)
                    {
                        if (enclosure.Animals.Contains(prey))
                        {
                            Console.WriteLine($"Warning: Predator {predator.Name} and prey {prey.Name} are housed together in {enclosure.Name}.");
                        }
                    }
                }

                var carnivores = enclosure.Animals.Where(a => a.Diet == DietaryClass.Carnivore).ToList();
                foreach (var herbivore in enclosure.Animals.Where(a => a.Diet == DietaryClass.Herbivore))
                {
                    if (carnivores.Any())
                    {
                        Console.WriteLine($"Warning: Herbivore {herbivore.Name} and carnivores are housed together in {enclosure.Name}.");
                    }
                }
            }

            Console.WriteLine("CheckConstraints completed.");
        }

        public void AutoAssign(bool completeExisting)
        {
            if (!completeExisting)
            {
                ClearExistingEnclosures();
            }

            var unassignedAnimals = _zoo.Animals.Where(a => a.EnclosureId == null).ToList();
            foreach (var unassignedAnimal in unassignedAnimals)
            {
                bool assigned = false;
                foreach (var enclosure in _zoo.Enclosures)
                {
                    double totalRequiredSpace = enclosure.Animals.Sum(a => a.SpaceRequirement);
                    if (totalRequiredSpace + unassignedAnimal.SpaceRequirement <= enclosure.Size &&
                        enclosure.SecurityLevel == unassignedAnimal.SecurityRequirement)
                    {
                        unassignedAnimal.EnclosureId = enclosure.Id;
                        enclosure.Animals.Add(unassignedAnimal);
                        assigned = true;
                        break;
                    }
                }

                if (!assigned)
                {
                    CreateNewEnclosureForAnimal(unassignedAnimal);
                }
            }

            _dbContext.SaveChanges(); // Save changes to the database
        }

        private void ClearExistingEnclosures()
        {
            _zoo.Enclosures.Clear();
        }

        private void CreateNewEnclosureForAnimal(Animal animal)
        {
            var newEnclosure = new Enclosure
            {
                Size = animal.SpaceRequirement,
                SecurityLevel = animal.SecurityRequirement,
                Animals = new List<Animal> { animal }
            };

            _dbContext.Enclosures.Add(newEnclosure); // Add to DbContext
            animal.EnclosureId = newEnclosure.Id; // Update animal's enclosure ID
        }
    }
}
