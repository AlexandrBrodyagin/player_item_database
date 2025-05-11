using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewProject.Data;
using NewProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PlayersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayers()
        {
            return await _context.Players.Include(p => p.Items).ToListAsync();
        }

        // POST: api/Players
        [HttpPost]
        public async Task<ActionResult<Player>> PostPlayer(Player player)
        {
            _context.Players.Add(player);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlayer", new { id = player.Id }, player);
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
         return Ok(_context.Players.Include(a => a.Items).ToList());
        }

        [HttpGet("players")]
        public async Task<IActionResult> GetAllPlayers()
        {
            return Ok(await _context.Players.ToListAsync());
        }
    }
}