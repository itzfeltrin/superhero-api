using Microsoft.AspNetCore.Mvc;

namespace FirstApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SuperHeroController : ControllerBase
{
    private static List<SuperHero> heroes = new List<SuperHero>
    {
        new SuperHero
        {
            Id = 1,
            Name = "Spider Man",
            FirstName = "Peter",
            LastName = "Parker",
            Place = "New York"
        }
    };
    
    [HttpGet]
    public async Task<ActionResult<List<SuperHero>>> Get()
    {
        return Ok(heroes);
    }

    [HttpPost]
    public async Task<ActionResult<List<SuperHero>>> AddHero([FromBody]SuperHero hero)
    {
        heroes.Add(hero);
        return Ok(heroes);
    }
}