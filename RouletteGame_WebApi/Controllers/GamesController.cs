using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RouletteGame_WebApi.Business;
using RouletteGame_WebApi.Business.Interfaces;
using RouletteGame_WebApi.Models;

namespace RouletteGame_WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly RouletteGameContext _context;

        public GamesController(RouletteGameContext context)
        {
            _context = context;
        }

        // GET: api/Games
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetGame()
        {
            return await _context.Game.ToListAsync();
        }

        // GET: api/Games/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGame(Guid id)
        {
            var game = await _context.Game.FindAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            return game;
        }

        [HttpPost(Name = "OpenGame")]
        public ActionResult<RequestResponse> OpenGame([Bind("rouletteId")] LaunchGame launchGame)
        {
            IGameBusiness gameBusiness = new GameBusiness(_context);
            RequestResponse response = gameBusiness.OpenGame(launchGame.RouletteId);

            if (response.SuccessFul == false)
            {
                return BadRequest(error: new { error = response.MessageError });
            }

            return Content("Proceso Exitoso");
        }

        [HttpPost(Name = "ClousedGame")]
        public ActionResult<RequestResponse> ClousedGame([Bind("rouletteId")] LaunchGame launchGame)
        {
            IGameBusiness gameBusiness = new GameBusiness(_context);
            RequestResponse response = gameBusiness.ClousedGame(launchGame.RouletteId);

            if (response.SuccessFul == false)
            {
                return BadRequest(error: new { error = response.MessageError });
            }

            return Content(response.MessageSuccess);
        }

        [HttpPost(Name = "GenerateBetGameByUserIdAndByRoulette")]
        public ActionResult<RequestResponse> GenerateBetGameByUserIdAndByRoulette([Bind("rouletteId,userId,betValue,number,color")] BetUser betUser)
        {
            IBetGameBusiness gameBusiness = new BetGameBusiness(_context);
            RequestResponse response = gameBusiness.GenerateBetGameByUserIdAndByRoulette(betUser);

            if (response.SuccessFul == false)
            {
                return BadRequest(error: new { error = response.MessageError });
            }

            return Content("Apuesta Generada con Exito");
        }
    }
}
