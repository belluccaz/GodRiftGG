using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GodRiftGG.API.Data;
using GodRift.API.Models;

namespace GodRift.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MatchPlayerController : ControllerBase
{
    private readonly GodRiftGGContext _context;

    public MatchPlayerController(GodRiftGGContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MatchPlayer>>> GetMatchPlayer()
    {
        return await _context.MatchPlayer.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MatchPlayer>> GetMatchPlayer(int id)
    {
        var matchPlayer = await _context.MatchPlayer.FindAsync(id);
        if (matchPlayer == null) return NotFound();
        return matchPlayer;
    }

    [HttpPost]
    public async Task<ActionResult<MatchPlayer>> PostMatchPlayer(MatchPlayer matchPlayer)
    {
        _context.MatchPlayer.Add(matchPlayer);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetMatchPlayer), new { id = matchPlayer.PlayerId }, matchPlayer);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutMatchPlayer(int id, MatchPlayer matchPlayer)
    {
        if (id != matchPlayer.PlayerId) return BadRequest();

        _context.Entry(matchPlayer).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.MatchPlayer.Any(e => e.PlayerId == id)) return NotFound();
            else throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMatchPlayer(int id)
    {
        var matchPlayer = await _context.MatchPlayer.FindAsync(id);
        if (matchPlayer == null) return NotFound();

        _context.MatchPlayer.Remove(matchPlayer);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
