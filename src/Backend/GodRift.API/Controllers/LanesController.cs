using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GodRiftGG.API.Data;
using GodRift.API.Models;

namespace GodRift.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LaneController : ControllerBase
{
    private readonly GodRiftGGContext _context;

    public LaneController(GodRiftGGContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Lane>>> GetLane()
    {
        return await _context.Lane.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Lane>> GetLane(int id)
    {
        var lane = await _context.Lane.FindAsync(id);
        if (lane == null) return NotFound();
        return lane;
    }

    [HttpPost]
    public async Task<ActionResult<Lane>> PostLane(Lane lane)
    {
        _context.Lane.Add(lane);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetLane), new { id = lane.LaneId }, lane);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutLane(int id, Lane lane)
    {
        if (id != lane.LaneId) return BadRequest();

        _context.Entry(lane).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Lane.Any(e => e.LaneId == id)) return NotFound();
            else throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLane(int id)
    {
        var lane = await _context.Lane.FindAsync(id);
        if (lane == null) return NotFound();

        _context.Lane.Remove(lane);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
