using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GodRiftGG.API.Data;

namespace GodRift.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BuildsController : ControllerBase
{
    private readonly GodRiftGGContext _context;

    public BuildsController(GodRiftGGContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Builds>>> GetBuilds()
    {
        return await _context.Builds.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Builds>> GetBuild(int id)
    {
        var build = await _context.Builds.FindAsync(id);
        if (build == null) return NotFound();
        return build;
    }

    [HttpPost]
    public async Task<ActionResult<Builds>> PostBuild(Builds build)
    {
        _context.Builds.Add(build);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetBuild), new { id = build.BuildId }, build);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutBuild(int id, Builds build)
    {
        if (id != build.BuildId) return BadRequest();

        _context.Entry(build).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Builds.Any(e => e.BuildId == id)) return NotFound();
            else throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBuild(int id)
    {
        var build = await _context.Builds.FindAsync(id);
        if (build == null) return NotFound();

        _context.Builds.Remove(build);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
