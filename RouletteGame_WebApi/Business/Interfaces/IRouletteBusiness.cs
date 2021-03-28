using RouletteGame_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouletteGame_WebApi.Business.Interfaces
{
    interface IRouletteBusiness
    {
        Roulette ConsultRouletteById(Guid rouletteId);
    }
}
