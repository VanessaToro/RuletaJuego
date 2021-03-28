using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RouletteGame_WebApi.Models;

namespace RouletteGame_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WinnerGamesController : ControllerBase
    {
        private readonly RouletteGameContext _context;

        public WinnerGamesController(RouletteGameContext context)
        {
            _context = context;
        }

        // GET: api/WinnerGames
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WinnerGame>>> GetWinnerGame()
        {
            return await _context.WinnerGame.ToListAsync();
        }

        // GET: api/WinnerGames/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WinnerGame>> GetWinnerGame(Guid id)
        {
            var winnerGame = await _context.WinnerGame.FindAsync(id);

            if (winnerGame == null)
            {
                return NotFound();
            }

            return winnerGame;
        }

        // PUT: api/WinnerGames/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWinnerGame(Guid id, WinnerGame winnerGame)
        {
            if (id != winnerGame.Id)
            {
                return BadRequest();
            }

            _context.Entry(winnerGame).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WinnerGameExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/WinnerGames
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WinnerGame>> PostWinnerGame(WinnerGame winnerGame)
        {
            _context.WinnerGame.Add(winnerGame);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWinnerGame", new { id = winnerGame.Id }, winnerGame);
        }

        // DELETE: api/WinnerGames/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWinnerGame(Guid id)
        {
            var winnerGame = await _context.WinnerGame.FindAsync(id);
            if (winnerGame == null)
            {
                return NotFound();
            }

            _context.WinnerGame.Remove(winnerGame);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WinnerGameExists(Guid id)
        {
            return _context.WinnerGame.Any(e => e.Id == id);
        }
    }
}
