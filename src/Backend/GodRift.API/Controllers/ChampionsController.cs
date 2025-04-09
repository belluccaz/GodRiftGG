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
    public async Task<ActionResult<IEnumerable<Champions>>> GetChampions()
    {
        return await _context.Champions.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Champions>> GetChampion(int id)
    {
        var champion = await _context.Champions.FindAsync(id);
        if (champion == null) return NotFound();
        return champion;
    }

    [HttpPost]
    public async Task<ActionResult<Champions>> PostChampion(Champions champion)
    {
        _context.Champions.Add(champion);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetChampion), new { id = champion.ChampionId }, champion);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutChampion(int id, Champions champion)
    {
        if (id != champion.ChampionId) return BadRequest();

        _context.Entry(champion).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Champions.Any(e => e.ChampionId == id)) return NotFound();
            else throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteChampion(int id)
    {
        var champion = await _context.Champions.FindAsync(id);
        if (champion == null) return NotFound();

        _context.Champions.Remove(champion);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
