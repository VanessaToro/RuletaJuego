using RouletteGame_WebApi.Business.Interfaces;
using RouletteGame_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouletteGame_WebApi.Business
{
    public class BetGameBusiness : IBetGameBusiness
    {
        private readonly RouletteGameContext _context;
        MessageError messageError = new();

        public BetGameBusiness(RouletteGameContext context)
        {
            _context = context;
        }

        public decimal ConsultBettingAmounts(Guid gameId)
        {
            return _context.BetGame.Where(bg => bg.GameId == gameId).Sum(s => s.BetValue);
        }

        public int ConsultTotalAccumulatedBet(Guid gameId)
        {
            return _context.BetGame.Where(bg => bg.GameId == gameId).Count();
        }

        public RequestResponse GenerateBetGameByUserIdAndByRoulette(BetUser betUser)
        {
            try
            {
                RequestResponse response = new RequestResponse();
                GameBusiness gameBusiness = new GameBusiness(_context);
                Guid gameId = gameBusiness.ConsultGameOpenByRouletteId(betUser.RouletteId).Id;

                if (betUser.BetValue > 10000 || gameId == Guid.NewGuid())
                {
                    return messageError.MapResponseError("Las apuestas no deben superar el valo de 10.000 USD, o la rulta ya se encuentra cerrada.");
                }
                BetGame betModel = new BetGame
                {
                    GameId = gameId,
                    UserId = betUser.UserId,
                    BetNumber = betUser.BetNumber,
                    BetColor = betUser.BetColor,
                    BetValue = betUser.BetValue,
                    BetDate = DateTime.Now,
                };
                _context.BetGame.Add(betModel);
                _context.SaveChanges();
                response.SuccessFul = true;

                return response;
            }
            catch (Exception ex)
            {
                return messageError.MapResponseError(ex.Message);
            }
        }
    }
}
