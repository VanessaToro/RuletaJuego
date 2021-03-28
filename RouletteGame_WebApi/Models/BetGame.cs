using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouletteGame_WebApi.Models
{
    public class BetGame
    {
        public Guid Id { get; set; }
        public Guid GameId { get; set; }
        public Guid UserId { get; set; }
        public int BetNumber { get; set; }
        public string BetColor { get; set; }
        public decimal BetValue { get; set; }
        public DateTime BetDate { get; set; }
    }
}
