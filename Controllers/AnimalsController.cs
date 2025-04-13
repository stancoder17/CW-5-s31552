using APBD05.Models;
using Microsoft.AspNetCore.Mvc;

namespace APBD05.Controllers;

[ApiController]
[Route("[controller]")]
public class AnimalsController : ControllerBase
{
    public static List<Animal> Animals =
    [
        new Animal()
        {
            Id = 1,
            Name = "Lucy",
            Category = "dog",
            Mass = 15.4,
            Color = "beige"
        },
        new Animal()
        {
            Id = 2,
            Name = "Sonia",
            Category = "dog",
            Mass = 14.9,
            Color = "brown"
        },
        new Animal()
        {
            Id = 3,
            Name = "Amidala",
            Category = "cat",
            Mass = 3.2,
            Color = "black"
        }
    ];

    // GET - list of all animals
    [HttpGet]
    public IActionResult GetAnimals()
    {
        return Ok(Animals);
    }

    // GET - animal by ID
    [HttpGet("{id}")]
    public IActionResult GetAnimal(int id)
    {
        if (Animals.Any(a => a.Id == id))
        {
            return Ok(Animals.FirstOrDefault(a => a.Id == id));
        }
        
        return NotFound();
    }
    
    
}