using AutoMapper;
using GodRift.API.DTOs;
using GodRift.API.Models;
using GodRiftGG.API.Data;
using GodRiftGG.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GodRift.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly GodRiftGGContext _context;
        private readonly IMapper _mapper;

        public PlayerController(GodRiftGGContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerDTO>>> GetPlayer()
        {
            var Player = await _context.Player.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<PlayerDTO>>(Player));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerDTO>> GetPlayer(long id)
        {
            var player = await _context.Player.FindAsync(id);
            if (player == null) return NotFound();

            return Ok(_mapper.Map<PlayerDTO>(player));
        }

        [HttpPost]
        public async Task<ActionResult<PlayerDTO>> CreatePlayer(CreatePlayerDTO dto)
        {
            var player = _mapper.Map<Player>(dto);
            _context.Player.Add(player);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPlayer), new { id = player.PlayerId }, _mapper.Map<PlayerDTO>(player));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(long id)
        {
            var player = await _context.Player.FindAsync(id);
            if (player == null) return NotFound();

            _context.Player.Remove(player);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
