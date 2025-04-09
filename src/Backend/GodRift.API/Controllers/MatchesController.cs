using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GodRiftGG.API.Data;
using GodRift.API.Models;

namespace GodRift.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MatchesController : ControllerBase
{
    private readonly GodRiftGGContext _context;

    public MatchesController(GodRiftGGContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Matches>>> GetMatches()
    {
        return await _context.Matches.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Matches>> GetMatch(int id)
    {
        var match = await _context.Matches.FindAsync(id);
        if (match == null) return NotFound();
        return match;
    }

    [HttpPost]
    public async Task<ActionResult<Matches>> PostMatch(Matches match)
    {
        _context.Matches.Add(match);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetMatch), new { id = match.MatchId }, match);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutMatch(int id, Matches match)
    {
        if (id != match.MatchId) return BadRequest();

        _context.Entry(match).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Matches.Any(e => e.MatchId == id)) return NotFound();
            else throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMatch(int id)
    {
        var match = await _context.Matches.FindAsync(id);
        if (match == null) return NotFound();

        _context.Matches.Remove(match);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}