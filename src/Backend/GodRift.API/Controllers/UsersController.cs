using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GodRiftGG.API.Data;
using GodRift.API.Models;
using GodRiftGG.API.Models;
using AutoMapper;
using GodRift.API.DTOs;

namespace GodRift.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly GodRiftGGContext _context;
    private readonly IMapper _mapper;

    public UsersController(GodRiftGGContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
    {
        var users = await _context.User
            .AsNoTracking()
            .ToListAsync();
        return Ok(_mapper.Map<IEnumerable<UserDTO>>(users));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDTO>> GetUser(long id)
    {
        var user = await _context.User.FindAsync(id);
        if (user == null)
            return NotFound();

        return Ok(_mapper.Map<UserDTO>(user));
    }

    [HttpPost]
    public async Task<ActionResult<User>> PostUser(User user)
    {
        user.CreatedAt = DateTime.UtcNow;
        _context.User.Add(user);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetUser), new { id = user.UserId }, user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutUser(long id, UpdateUserDTO userDto)
    {
        if (id != userDto.UserId)
            return BadRequest();

        var user = await _context.User.FindAsync(id);
        if (user == null)
            return NotFound();

        _mapper.Map(userDto, user);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await UserExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await _context.User.FindAsync(id);
        if (user == null) return NotFound();

        _context.User.Remove(user);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private async Task<bool> UserExists(long id)
    {
        return await _context.User.AnyAsync(e => e.UserId == id);
    }
}
