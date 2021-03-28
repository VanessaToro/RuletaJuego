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
    public class RoulettesController : ControllerBase
    {
        private readonly RouletteGameContext _context;

        public RoulettesController(RouletteGameContext context)
        {
            _context = context;
        }

        // GET: api/Roulettes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Roulette>>> GetRoulette()
        {
            return await _context.Roulette.ToListAsync();
        }

        // GET: api/Roulettes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Roulette>> GetRoulette(Guid id)
        {
            var roulette = await _context.Roulette.FindAsync(id);

            if (roulette == null)
            {
                return NotFound();
            }

            return roulette;
        }

        // POST: api/Roulettes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Roulette>> PostRoulette(Roulette roulette)
        {
            _context.Roulette.Add(roulette);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoulette", new { id = roulette.Id }, "Roulette Id " + roulette.Id);
        }
    }
}
