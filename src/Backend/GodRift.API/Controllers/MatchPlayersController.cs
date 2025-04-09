using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GodRiftGG.API.Data;
using GodRift.API.Models;

namespace GodRift.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MatchPlayersController : ControllerBase
{
    private readonly GodRiftGGContext _context;

    public MatchPlayersController(GodRiftGGContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MatchPlayers>>> GetMatchPlayers()
    {
        return await _context.MatchPlayers.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MatchPlayers>> GetMatchPlayer(int id)
    {
        var matchPlayer = await _context.MatchPlayers.FindAsync(id);
        if (matchPlayer == null) return NotFound();
        return matchPlayer;
    }

    [HttpPost]
    public async Task<ActionResult<MatchPlayers>> PostMatchPlayer(MatchPlayers matchPlayer)
    {
        _context.MatchPlayers.Add(matchPlayer);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetMatchPlayer), new { id = matchPlayer.PlayerId }, matchPlayer);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutMatchPlayer(int id, MatchPlayers matchPlayer)
    {
        if (id != matchPlayer.PlayerId) return BadRequest();

        _context.Entry(matchPlayer).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.MatchPlayers.Any(e => e.PlayerId == id)) return NotFound();
            else throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMatchPlayer(int id)
    {
        var matchPlayer = await _context.MatchPlayers.FindAsync(id);
        if (matchPlayer == null) return NotFound();

        _context.MatchPlayers.Remove(matchPlayer);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
