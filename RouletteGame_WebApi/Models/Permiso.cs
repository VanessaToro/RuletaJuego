using System;
using System.Collections.Generic;

#nullable disable

namespace RouletteGame_WebApi.Models
{
    public partial class Permiso
    {
        public Permiso()
        {
            PermisosRoles = new HashSet<PermisosRole>();
        }

        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<PermisosRole> PermisosRoles { get; set; }
    }
}
