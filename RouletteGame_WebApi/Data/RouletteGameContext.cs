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

        public DbSet<RouletteGame_WebApi.Models.Usuarios> Usuario { get; set; }

        public DbSet<RouletteGame_WebApi.Models.Role> Role { get; set; }
    }
