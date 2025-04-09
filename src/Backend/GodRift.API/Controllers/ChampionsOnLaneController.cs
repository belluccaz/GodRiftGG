using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GodRift.API.Data;
using GodRift.API.Models;

namespace GodRift.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChampionsOnLaneController : ControllerBase
{
    private readonly GodRiftContext _context;

    public ChampionsOnLaneController(GodRiftContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ChampionsOnLane>>> GetChampionsOnLanes()
    {
        return await _context.ChampionsOnLane.ToListAsync();
    }

    [HttpGet("{championId}/{laneId}")]
    public async Task<ActionResult<ChampionsOnLane>> GetChampionOnLane(int championId, int laneId)
    {
        var entry = await _context.ChampionsOnLane.FindAsync(championId, laneId);
        if (entry == null) return NotFound();
        return entry;
    }

    [HttpPost]
    public async Task<ActionResult<ChampionsOnLane>> PostChampionOnLane(ChampionsOnLane entry)
    {
        _context.ChampionsOnLane.Add(entry);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetChampionOnLane), new { championId = entry.ChampionId, laneId = entry.LaneId }, entry);
    }

    [HttpDelete("{championId}/{laneId}")]
    public async Task<IActionResult> DeleteChampionOnLane(int championId, int laneId)
    {
        var entry = await _context.ChampionsOnLane.FindAsync(championId, laneId);
        if (entry == null) return NotFound();

        _context.ChampionsOnLane.Remove(entry);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
