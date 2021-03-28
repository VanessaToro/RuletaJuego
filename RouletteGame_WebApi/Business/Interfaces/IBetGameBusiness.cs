using RouletteGame_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouletteGame_WebApi.Business.Interfaces
{
    public interface IBetGameBusiness
    {
        int ConsultTotalAccumulatedBet(Guid gameId);
        decimal ConsultBettingAmounts(Guid gameId);
        RequestResponse GenerateBetGameByUserIdAndByRoulette(BetUser betUser);

    }
}
