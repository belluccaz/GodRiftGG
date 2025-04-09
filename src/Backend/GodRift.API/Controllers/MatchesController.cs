using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GodRiftGG.API.Data;
using GodRift.API.Models;

namespace GodRift.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MatchController : ControllerBase
{
    private readonly GodRiftGGContext _context;

    public MatchController(GodRiftGGContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Match>>> GetMatch()
    {
        return await _context.Match.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Match>> GetMatch(int id)
    {
        var match = await _context.Match.FindAsync(id);
        if (match == null) return NotFound();
        return match;
    }

    [HttpPost]
    public async Task<ActionResult<Match>> PostMatch(Match match)
    {
        _context.Match.Add(match);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetMatch), new { id = match.MatchId }, match);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutMatch(int id, Match match)
    {
        if (id != match.MatchId) return BadRequest();

        _context.Entry(match).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Match.Any(e => e.MatchId == id)) return NotFound();
            else throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMatch(int id)
    {
        var match = await _context.Match.FindAsync(id);
        if (match == null) return NotFound();

        _context.Match.Remove(match);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}