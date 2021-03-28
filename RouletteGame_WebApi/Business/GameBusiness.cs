using RouletteGame_WebApi.Business.Interfaces;
using RouletteGame_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouletteGame_WebApi.Business
{
    public class GameBusiness : IGameBusiness
    {
        private readonly RouletteGameContext _context;
        MessageError messageError = new();

        public GameBusiness(RouletteGameContext context)
        {
            _context = context;
        }

        public RequestResponse ClousedGame(Guid rouletteId)
        {
            try
            {
                BetGameBusiness betGameBusiness = new BetGameBusiness(_context);
                bool rouletteOpen = ValidateExistOpenRouletteInGame(rouletteId);
                if (rouletteOpen)
                {
                    Guid gameId = ConsultGameOpenByRouletteId(rouletteId).Id;
                    Random random = new Random();
                    int winner = random.Next(0, 33);

                    Game game = new Game();
                    game.Id = gameId;
                    game.RouletteId = rouletteId;
                    game.Open = false;
                    game.WinnerNumber = winner;
                    game.WinnerColor = ((winner % 2) == 0 ? "Rojo" : "Negro");
                    game.GameEndDate = DateTime.Now;
                    game.TotalAccumulatedBet = betGameBusiness.ConsultTotalAccumulatedBet(gameId);
                    game.BettingAmount = betGameBusiness.ConsultBettingAmounts(gameId);
                    _context.Game.Update(game);
                    _context.SaveChanges();

                    return new RequestResponse() { SuccessFul = true, MessageSuccess = "Ganado " +  winner.ToString() + ", " + game.WinnerColor };
                }

                return messageError.MapResponseError("La ruleta enviada actualmente se encuentra abierta en un juego.");
            }
            catch (Exception ex)
            {
                return messageError.MapResponseError(ex.Message);
            }          
        }

        public Game ConsultGameOpenByRouletteId(Guid rouletteId)
        {
          return  _context.Game.Where(g => g.RouletteId == rouletteId && g.Open == true).FirstOrDefault();
        }

        public RequestResponse OpenGame(Guid rouletteId)
        {
            try
            {
                bool rouletteOpen = ValidateExistOpenRouletteInGame(rouletteId);
                if (rouletteOpen)
                {
                    return messageError.MapResponseError("La ruleta enviada actualmente se encuentra abierta en un juego.");
                }
                Game game = new Game();
                game.RouletteId = rouletteId;
                game.Open = true;
                game.WinnerNumber = 0;
                game.WinnerColor = "Sin Jugar";
                game.TotalAccumulatedBet = 0;
                game.BettingAmount = 0;
                game.GameStartDate = DateTime.Now;
                game.GameEndDate = null;
                _context.Game.Add(game);
                _context.SaveChanges();

                return new RequestResponse() { SuccessFul = true };
            }
            catch (Exception ex)
            {
                return messageError.MapResponseError(ex.Message);
            }
        }

        public bool ValidateExistOpenRouletteInGame(Guid rouletteId)
        {
            var rouletteInGame = _context.Game.Where(g => g.RouletteId == rouletteId && g.Open == true).FirstOrDefault();
            return (rouletteInGame != null ? true : false);
        }
    }
}
