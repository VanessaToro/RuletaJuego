using System;
using System.Collections.Generic;

#nullable disable

namespace RouletteGame_WebApi.Models
{
    public partial class PermisosRole
    {
        public Guid Id { get; set; }
        public Guid Rolid { get; set; }
        public Guid PermisoId { get; set; }

        public virtual Permiso Permiso { get; set; }
        public virtual Role Rol { get; set; }
    }
}
