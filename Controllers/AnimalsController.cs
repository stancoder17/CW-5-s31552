using APBD05.Models;
using Microsoft.AspNetCore.Mvc;

namespace APBD05.Controllers;

[ApiController]
[Route("[controller]")]
public class AnimalsController : ControllerBase
{
    // GET - all animals
    [HttpGet]
    public IActionResult GetAnimals()
    {
        return Ok(Database.Animals);
    }

    // GET - animal by ID
    [HttpGet("id/{id}")]
    public IActionResult GetAnimal(int id)
    {
        if (Database.Animals.Any(a => a.Id == id))
        {
            return Ok(Database.Animals.FirstOrDefault(a => a.Id == id));
        }

        return NotFound();
    }

    // POST - one animal
    [HttpPost]
    public IActionResult AddAnimal(Animal animal)
    {
        animal.Id = GetNextId();
        Database.Animals.Add(animal);
        return CreatedAtAction(nameof(GetAnimal), new { id = animal.Id }, animal);
    }

    // PUT - update one animal
    [HttpPut("{id}")]
    public IActionResult UpdateAnimal(int id, Animal animal)
    {
        var existingAnimal = Database.Animals.FirstOrDefault(a => a.Id == id);

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

    // DELETE - one animal
    [HttpDelete("{id}")]
    public IActionResult DeleteAnimal(int id)
    {
        var existingAnimal = Database.Animals.FirstOrDefault(a => a.Id == id);

        if (existingAnimal == null)
        {
            return NotFound();
        }

        Database.Animals.Remove(existingAnimal);

        return NoContent();
    }

    // GET - animals by name
    [HttpGet("name/{name}")]
    public IActionResult GetAnimals(string name)
    {
        var existingAnimals = Database.Animals.Where(a => a.Name == name);

        if (!existingAnimals.Any())
        {
            return NotFound();
        }
        
        return Ok(existingAnimals);
    }
    
    private static int GetNextId()
    {
        return Database.Animals.Max(a => a.Id) + 1;
    }
}