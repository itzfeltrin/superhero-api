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
            Name = "Batman",
            FirstName = "Bruce",
            LastName = "Wayne",
            Place = "Gotham City"
        },
        new SuperHero {
            Id = 2,
            Name = "Iron Man",
            FirstName = "Tony",
            LastName = "Stark",
            Place = "Long Island"
        }
    };
    
    [HttpGet]
    public async Task<ActionResult<List<SuperHero>>> Get()
    {
        return Ok(heroes);
    }

    [HttpGet("{heroId:int}")]
    public async Task<ActionResult<SuperHero>> Get([FromRoute]int heroId)
    {
        var hero = heroes.Find(hero => hero.Id.Equals(heroId));
        if (hero == null)
            return BadRequest("Hero not found");
        return Ok(hero);
    }
    
    [HttpPost]
    public async Task<ActionResult<List<SuperHero>>> AddHero([FromBody]SuperHero hero)
    {
        heroes.Add(hero);
        return Ok(heroes);
    }
}