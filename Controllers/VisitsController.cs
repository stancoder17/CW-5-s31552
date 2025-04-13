using APBD05.Models;
using Microsoft.AspNetCore.Mvc;

namespace APBD05.Controllers;

[ApiController]
[Route("[controller]")]
public class VisitsController : ControllerBase
{
    [HttpGet("{name}")]
    public IActionResult GetVisits(string name)
    {
        var visits = Database.Visits
            .Where(v => v.Animal.Name == name);

        if (!visits.Any())
        {
            return NotFound("No visits found for the animal with the given name.");
        }
        
        return Ok(visits);
    }

    [HttpPost]
    public IActionResult Add(Visit visit)
    {
        // If animal not in Database
        if (!Database.Animals.Any(a => a.Id == visit.Animal.Id))
        {
            return BadRequest("Animal not in the database");
        }
        
        Database.Visits.Add(visit);
        
        return CreatedAtAction(nameof(GetVisits), new { name = visit.Animal.Name }, visit);
    }
}