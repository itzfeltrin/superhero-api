using Microsoft.AspNetCore.Mvc;

namespace FirstApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SuperHeroController : ControllerBase
{
    private readonly DataContext _context;

    public SuperHeroController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<SuperHero>>> Get()
    {
        var heroes = await _context.SuperHeroes.ToListAsync();
        return Ok(heroes);
    }

    [HttpGet("{heroId:int}")]
    public async Task<ActionResult<SuperHero>> Get([FromRoute] int heroId)
    {
        if (heroId <= 0) return BadRequest("Invalid Id");
        var hero = await _context.SuperHeroes.FindAsync(heroId);
        if (hero == null) return NotFound("Hero not found");
        return Ok(hero);
    }

    [HttpPost]
    public async Task<ActionResult<List<SuperHero>>> AddHero([FromBody] SuperHero hero)
    {
        _context.SuperHeroes.Add(hero);
        await _context.SaveChangesAsync();
        var heroes = await _context.SuperHeroes.ToListAsync();
        return Ok(heroes);
    }

    [HttpPut("{heroId:int}")]
    public async Task<ActionResult<List<SuperHero>>> UpdateHero(int heroId, [FromBody] SuperHero request)
    {
        if (heroId <= 0) return BadRequest("Invalid Id");
        var hero = await _context.SuperHeroes.FindAsync(heroId);
        if (hero == null) return NotFound("Hero not found");
        hero.Name = request.Name;
        hero.FirstName = request.FirstName;
        hero.LastName = request.LastName;
        hero.Place = request.Place;
        await _context.SaveChangesAsync();
        var heroes = await _context.SuperHeroes.ToListAsync();
        return Ok(heroes);
    }

    [HttpDelete("{heroId:int}")]
    public async Task<ActionResult<List<SuperHero>>> DeleteHero(int heroId)
    {
        if (heroId <= 0) return BadRequest("Invalid Id");
        var hero = await _context.SuperHeroes.FindAsync(heroId);
        if (hero == null)
            return NotFound("Hero not found");
        _context.SuperHeroes.Remove(hero);
        await _context.SaveChangesAsync();
        var heroes = await _context.SuperHeroes.ToListAsync();
        return heroes;
    }
}