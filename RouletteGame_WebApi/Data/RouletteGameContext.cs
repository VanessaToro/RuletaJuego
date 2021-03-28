using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RouletteGame_WebApi.Models;

    public class RouletteGameContext : DbContext
    {
        public RouletteGameContext (DbContextOptions<RouletteGameContext> options)
            : base(options)
        {
        }

        public DbSet<RouletteGame_WebApi.Models.User> User { get; set; }

        public DbSet<RouletteGame_WebApi.Models.Roulette> Roulette { get; set; }

        public DbSet<RouletteGame_WebApi.Models.Game> Game { get; set; }

        public DbSet<RouletteGame_WebApi.Models.BetGame> BetGame { get; set; }

        public DbSet<RouletteGame_WebApi.Models.WinnerGame> WinnerGame { get; set; }
    }
