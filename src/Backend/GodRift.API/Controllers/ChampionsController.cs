using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GodRiftGG.API.Data;
using GodRiftGG.Models;

namespace GodRift.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChampionsController : ControllerBase
{
    private readonly GodRiftGGContext _context;

    public ChampionsController(GodRiftGGContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Champion>>> GetChampions()
    {
        return await _context.Champion.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Champion>> GetChampion(int id)
    {
        var champion = await _context.Champion.FindAsync(id);
        if (champion == null) return NotFound();
        return champion;
    }

    [HttpPost]
    public async Task<ActionResult<Champion>> PostChampion(Champion champion)
    {
        _context.Champion.Add(champion);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetChampion), new { id = champion.ChampionId }, champion);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutChampion(int id, Champion champion)
    {
        if (id != champion.ChampionId) return BadRequest();

        _context.Entry(champion).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Champion.Any(e => e.ChampionId == id)) return NotFound();
            else throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteChampion(int id)
    {
        var champion = await _context.Champion.FindAsync(id);
        if (champion == null) return NotFound();

        _context.Champion.Remove(champion);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
