using RouletteGame_WebApi.Business.Interfaces;
using RouletteGame_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouletteGame_WebApi.Business
{
    public class RouletteBusiness : IRouletteBusiness
    {
        private readonly RouletteGameContext _context;
        MessageError messageError = new();

        public RouletteBusiness(RouletteGameContext context)
        {
            _context = context;
        }

        public Roulette ConsultRouletteById(Guid rouletteId)
        {
            throw new NotImplementedException();
        }
    }
}
