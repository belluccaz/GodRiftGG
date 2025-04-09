using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GodRiftGG.API.Data;
using GodRift.API.Models;

namespace GodRift.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayersMatchItemsController : ControllerBase
{
    private readonly GodRiftGGContext _context;

    public PlayersMatchItemsController(GodRiftGGContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PlayersMatchItem>>> GetPlayersMatchItems()
    {
        return await _context.PlayerMatchItems.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PlayersMatchItem>> GetPlayersMatchItem(int id)
    {
        var item = await _context.PlayerMatchItems.FindAsync(id);
        if (item == null) return NotFound();
        return item;
    }

    [HttpPost]
    public async Task<ActionResult<PlayersMatchItem>> PostPlayersMatchItem(PlayersMatchItem item)
    {
        _context.PlayerMatchItems.Add(item);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetPlayersMatchItem), new { id = item.ItemId }, item);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutPlayersMatchItem(int id, PlayersMatchItem item)
    {
        if (id != item.ItemId) return BadRequest();

        _context.Entry(item).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.PlayerMatchItems.Any(e => e.ItemId == id)) return NotFound();
            else throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePlayersMatchItem(int id)
    {
        var item = await _context.PlayerMatchItems.FindAsync(id);
        if (item == null) return NotFound();

        _context.PlayerMatchItems.Remove(item);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
