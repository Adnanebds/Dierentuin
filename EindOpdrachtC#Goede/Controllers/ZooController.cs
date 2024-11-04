using EindOpdrachtC_Goede.Models.Enums;
using EindOpdrachtC_Goede.Models;
using System; // Don't forget to include System
using System.Collections.Generic; // Required for List<T>
using System.Linq; // Required for LINQ operations

namespace Dierentuin.Controllers
{
    public class ZooController
    {
        public class Zoo
        {
            public List<Animal> Animals { get; set; }
            public List<Enclosure> Enclosures { get; set; }

            public Zoo()
            {
                Animals = new List<Animal>();
                Enclosures = new List<Enclosure>();
            }

            // Methodes voor de verschillende acties
            public void Sunrise()
            {
                foreach (var animal in Animals)
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
                foreach (var animal in Animals)
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
                Random rand = new Random(); // Create a single instance of Random

                foreach (var animal in Animals) // This 'animal' represents each animal in the zoo.
                {
                    if (animal.Diet == DietaryClass.Carnivore) // Check if the animal is a carnivore
                    {
                        // Here we use 'a' as a temporary variable to represent each animal during filtering.
                        var selectedPrey = Animals
                            .Where(a => a.Id != animal.Id && a.Size < animal.Size) // 'a' is each animal in the Animals list
                            .FirstOrDefault(); // Get the first animal that is not the current one and is smaller

                        if (selectedPrey != null) // If we found a prey
                        {
                            Console.WriteLine($"{animal.Name} is aan het eten {selectedPrey.Name}.");
                        }
                        else // If no prey is found
                        {
                            Console.WriteLine($"{animal.Name} heeft geen prooi gevonden.");
                        }
                    }
                    else if (animal.Diet == DietaryClass.Herbivore)
                    {
                        List<string> plantFoods = new List<string> { "Grass", "Leaves", "Fruits", "Vegetables" }; // This is dynamic
                        int randomIndex = rand.Next(plantFoods.Count); // Dynamically gets a random index
                        string selectedHerb = plantFoods[randomIndex]; // Selects the food item based on the random index

                        Console.WriteLine($"{animal.Name} is eating {selectedHerb}.");
                    }
                    else if (animal.Diet == DietaryClass.Omnivore)
                    {
                        // Randomly decide whether the omnivore eats plant or animal food
                        if (rand.Next(2) == 0) // 50% chance for each type
                        {
                            // Plant food
                            List<string> plantFoods = new List<string> { "Grass", "Leaves", "Fruits", "Vegetables" };
                            int randomIndex = rand.Next(plantFoods.Count);
                            string selectedPlantFood = plantFoods[randomIndex];

                            Console.WriteLine($"{animal.Name} is eating {selectedPlantFood}.");
                        }
                        else
                        {
                            // Animal food
                            var selectedPrey = Animals
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
                // Logic to check constraints or requirements
            }
        }
    }
}
