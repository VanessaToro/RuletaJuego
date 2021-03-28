using RouletteGame_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouletteGame_WebApi.Business.Interfaces
{
    public interface IGameBusiness
    {
        bool ValidateExistOpenRouletteInGame(Guid rouletteId);
        RequestResponse OpenGame(Guid rouletteId);
        RequestResponse ClousedGame(Guid rouletteId);
        Game ConsultGameOpenByRouletteId(Guid rouletteId);
    }
}
