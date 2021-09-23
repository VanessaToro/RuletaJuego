using Microsoft.EntityFrameworkCore;


#nullable disable

namespace RouletteGame_WebApi.Models
{
    public partial class AutenticacionContext : DbContext
    {
        public AutenticacionContext()
        {
        }

        public AutenticacionContext(DbContextOptions<AutenticacionContext> options)
            : base(options)
        {
        }

        public  DbSet<Permiso> Permisos { get; set; }
        public  DbSet<PermisosRole> PermisosRoles { get; set; }
        public  DbSet<Role> Roles { get; set; }
        public  DbSet<Usuarios> Usuarios { get; set; }
    }
}
