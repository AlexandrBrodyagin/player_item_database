using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using newProject.Models;
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
        public async Task<ActionResult<IEnumerable<PlayerWithItemsDto>>> GetPlayers()
        {
            var players = await _context.Players
                .Select(p => new PlayerWithItemsDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Items = (p.Items ?? new List<Items>()).Select(i => new ItemDto
                    {
                        Name = i.Name,
                        Price = i.Price,
                        PlayerId = i.PlayerId
                    }).ToList()
                })
                .ToListAsync();

                if (players == null)
                {
                    return NotFound();
                }

            return players;
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