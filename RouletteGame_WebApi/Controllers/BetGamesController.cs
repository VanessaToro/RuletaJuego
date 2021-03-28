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
    public class BetGamesController : ControllerBase
    {
        private readonly RouletteGameContext _context;

        public BetGamesController(RouletteGameContext context)
        {
            _context = context;
        }

        // GET: api/BetGames
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BetGame>>> GetBetGame()
        {
            return await _context.BetGame.ToListAsync();
        }

        // GET: api/BetGames/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BetGame>> GetBetGame(Guid id)
        {
            var betGame = await _context.BetGame.FindAsync(id);

            if (betGame == null)
            {
                return NotFound();
            }

            return betGame;
        }

        // PUT: api/BetGames/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBetGame(Guid id, BetGame betGame)
        {
            if (id != betGame.Id)
            {
                return BadRequest();
            }

            _context.Entry(betGame).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BetGameExists(id))
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

        // POST: api/BetGames
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BetGame>> PostBetGame(BetGame betGame)
        {
            _context.BetGame.Add(betGame);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBetGame", new { id = betGame.Id }, betGame);
        }

        // DELETE: api/BetGames/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBetGame(Guid id)
        {
            var betGame = await _context.BetGame.FindAsync(id);
            if (betGame == null)
            {
                return NotFound();
            }

            _context.BetGame.Remove(betGame);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BetGameExists(Guid id)
        {
            return _context.BetGame.Any(e => e.Id == id);
        }
    }
}
