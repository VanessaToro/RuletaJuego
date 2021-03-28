using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouletteGame_WebApi.Models
{
    public class WinnerGame
    {
        public Guid Id { get; set; }
        public Guid GameId { get; set; }
        public Guid UserId { get; set; }
        public decimal GameValue { get; set; }
        public DateTime CreateDat { get; set; }
    }
}
