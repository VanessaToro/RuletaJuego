using System;
using System.Collections.Generic;

#nullable disable

namespace RouletteGame_WebApi.Models
{
    public partial class Usuarios
    {
        public Guid Id { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NombreCompleto { get; set; }
        public string Direccion { get; set; }
        public string NumeroContacto { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public Guid RolId { get; set; }
        public DateTime FechaCracionRegistro { get; set; }
        public DateTime? FechaUltimaActualziacion { get; set; }
        public string UsuarioModifico { get; set; }
        public bool? Estado { get; set; }

        public virtual Role Rol { get; set; }
    }
}
