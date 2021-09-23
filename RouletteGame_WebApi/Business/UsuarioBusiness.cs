using RouletteGame_WebApi.Business.Interfaces;
using RouletteGame_WebApi.Models;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace RouletteGame_WebApi.Business
{
    public class UsuarioBusiness : IUsuarioBusiness
    {
        private readonly AutenticacionContext _context;
        MessageError messageError = new();

        public UsuarioBusiness(AutenticacionContext context)
        {
            _context = context;
        }

        public RequestResponse ActualizarUsuario(PeticionUsuario user)
        {
            try
            {
                RequestResponse response = new RequestResponse();
                Usuarios userModel = new Usuarios
                {
                    Nombres = user.Nombres,
                    Apellidos = user.Apellidos,
                    NumeroIdentificacion = user.NumeroIdentificacion,
                    NombreCompleto = user.Nombres + " " + user.Apellidos,
                    Direccion = user.Direccion,
                    NumeroContacto = user.NumeroContacto,
                    FechaNacimiento = user.FechaNacimiento,
                    Clave = EncryptPasswordUser(user.Clave),
                    FechaUltimaActualziacion = DateTime.Now,
                    Estado = true,
                    RolId = user.RolId,
                    UsuarioModifico = user.UsuarioModifico
                };
                _context.Update(userModel);
                _context.SaveChangesAsync();
                response.SuccessFul = true;

                return response;
            }
            catch (Exception ex)
            {
                return messageError.MapResponseError(ex.Message);
            }
        }

        public RequestResponse CrearUsuario(PeticionUsuario user)
        {
            try
            {
                RequestResponse response = new RequestResponse();
                Usuarios userModel = new Usuarios
                {
                    Nombres = user.Nombres,
                    Apellidos = user.Apellidos,
                    NumeroIdentificacion = user.NumeroIdentificacion,
                    NombreCompleto = user.Nombres + " " + user.Apellidos,
                    Direccion = user.Direccion,
                    NumeroContacto = user.NumeroContacto,
                    FechaNacimiento = user.FechaNacimiento,
                    Usuario = user.Usuario,
                    Clave = EncryptPasswordUser(user.Clave),
                    FechaCracionRegistro = DateTime.Now,
                    Estado = true,
                    RolId = user.RolId,
                    UsuarioModifico = user.UsuarioModifico
                };
                _context.Usuarios.Add(userModel);
                _context.SaveChanges();
                response.SuccessFul = true;

                return response;
            }
            catch (Exception ex)
            {
                return messageError.MapResponseError(ex.Message);
            }
        }

        public string DecryptPasswordUser(string encriptPassword)
        {
            try
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] result = Convert.FromBase64String(encriptPassword);
                return UTF8Encoding.UTF8.GetString(result);
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        public string EncryptPasswordUser(string password)
        {
            try
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));
                byte[] result = md5.Hash;
                return Convert.ToBase64String(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Usuarios ValidarAutenticacionUsuario(string usuario, string clave)
        {
            try
            {
                Usuarios respuesta = new Usuarios();

                if (!string.IsNullOrEmpty(usuario) || !string.IsNullOrEmpty(clave))
                {             
                    string claveEncriptada = EncryptPasswordUser(clave);
                    var query = from u in _context.Usuarios
                                    where u.Usuario == usuario && u.Clave == claveEncriptada
                                    join r in _context.Roles on u.RolId equals r.Id into user_join
                                    from roluser in user_join.DefaultIfEmpty()
                                    select new Usuarios()
                                    {
                                        Id = u.Id,
                                        NumeroIdentificacion = u.NumeroIdentificacion,
                                        Nombres = u.Nombres,
                                        Apellidos = u.Apellidos,
                                        NombreCompleto = u.NombreCompleto,
                                        Direccion = u.Direccion,
                                        NumeroContacto = u.NumeroContacto,
                                        FechaNacimiento = u.FechaNacimiento,
                                        Usuario = u.Usuario,
                                        Estado = u.Estado,
                                        Rol = new Role
                                        {
                                            Id = roluser.Id,
                                            Nombre = roluser.Nombre
                                        }
                                    };

                    respuesta = query.FirstOrDefault();
                }
                return respuesta;      
            }
            catch (Exception)
            {

                throw;
            }
    
        }
    }
}
