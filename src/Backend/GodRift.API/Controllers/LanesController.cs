using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GodRift.API.Data;
using GodRift.API.Models;

namespace GodRift.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LanesController : ControllerBase
{
    private readonly GodRiftContext _context;

    public LanesController(GodRiftContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Lanes>>> GetLanes()
    {
        return await _context.Lanes.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Lanes>> GetLane(int id)
    {
        var lane = await _context.Lanes.FindAsync(id);
        if (lane == null) return NotFound();
        return lane;
    }

    [HttpPost]
    public async Task<ActionResult<Lanes>> PostLane(Lanes lane)
    {
        _context.Lanes.Add(lane);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetLane), new { id = lane.LaneId }, lane);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutLane(int id, Lanes lane)
    {
        if (id != lane.LaneId) return BadRequest();

        _context.Entry(lane).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Lanes.Any(e => e.LaneId == id)) return NotFound();
            else throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLane(int id)
    {
        var lane = await _context.Lanes.FindAsync(id);
        if (lane == null) return NotFound();

        _context.Lanes.Remove(lane);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
