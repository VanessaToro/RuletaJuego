using RouletteGame_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouletteGame_WebApi.Business.Interfaces
{
    public interface IUsuarioBusiness
    {
        string EncryptPasswordUser(string password);

        string DecryptPasswordUser(string encriptPassword);

        RequestResponse CrearUsuario(PeticionUsuario user);
        RequestResponse ActualizarUsuario(PeticionUsuario user);

        Usuarios ValidarAutenticacionUsuario(string usuario, string clave);
    }
}
