using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RouletteGame_WebApi.Models
{
    public class Game
    {
        [Key]
        public Guid Id { get; set; }
        public Guid RouletteId  { get; set; }
        public bool Open { get; set; }
        public int WinnerNumber  { get; set; }
        public string WinnerColor { get; set; }
        public decimal BettingAmount  { get; set; }
        public int TotalAccumulatedBet { get; set; }
        public DateTime GameStartDate{ get; set; }
        public DateTime? GameEndDate { get; set; }
    }
}
