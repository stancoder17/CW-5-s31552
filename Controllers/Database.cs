using APBD05.Models;

namespace APBD05.Controllers;

public static class Database
{
    // Animals
    public static readonly List<Animal> Animals =
    [
        new Animal { Id = 1, Name = "Lucy", Category = "dog", Mass = 15.4, Color = "beige" },
        new Animal { Id = 2, Name = "Sonia", Category = "dog", Mass = 14.9, Color = "brown" },
        new Animal { Id = 3, Name = "Amidala", Category = "cat", Mass = 3.2, Color = "black" }
    ];
    
    // Visits
    public static readonly List<Visit> Visits =
    [
        new Visit
        {
            Animal = Animals.FirstOrDefault(a => a.Id == 1), Date = DateTime.Parse("2021-09-25"),
            Description = "Regular health check", Price = 15
        },
        new Visit
        {
            Animal = Animals.FirstOrDefault(a => a.Id == 2), Date = DateTime.Parse("2021-09-26"),
            Description = "Anti-parasite shot", Price = 78.5
        },
        new Visit
        {
            Animal = Animals.FirstOrDefault(a => a.Id == 3), Date = DateTime.Parse("2021-09-26"),
            Description = "Showering", Price = 38.12
        }
    ];
}