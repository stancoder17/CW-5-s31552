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
    [HttpGet("id/{id}")]
    public IActionResult GetAnimal(int id)
    {
        if (Animals.Any(a => a.Id == id))
        {
            return Ok(Animals.FirstOrDefault(a => a.Id == id));
        }
        
        return NotFound();
    }

    // POST - new animal
    [HttpPost]
    public IActionResult AddAnimal(Animal animal)
    {
        animal.Id = GetNextId();
        
        Animals.Add(animal);
        
        return CreatedAtAction(nameof(GetAnimal), new { id = animal.Id }, animal);
    }
    
    // PUT - update animal
    [HttpPut("{id}")]
    public IActionResult UpdateAnimal(int id, Animal animal)
    {
        var existingAnimal = Animals.FirstOrDefault(a => a.Id == id);

        if (existingAnimal == null)
        {
            return NotFound();
        }
        
        existingAnimal.Name = animal.Name;
        existingAnimal.Category = animal.Category;
        existingAnimal.Mass = animal.Mass;
        existingAnimal.Color = animal.Color;
        
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAnimal(int id)
    {
        var existingAnimal = Animals.FirstOrDefault(a => a.Id == id);

        if (existingAnimal == null)
        {
            return NotFound();
        }
        
        Animals.Remove(existingAnimal);
        
        return NoContent();
    }

    [HttpGet("name/{name}")]
    public IActionResult GetAnimals(string name)
    {
        return Ok(Animals.Where(a => a.Name == name));
    }

    private int GetNextId()
    {
        return Animals.Max(a => a.Id) + 1;
    }
}