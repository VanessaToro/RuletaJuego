using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RouletteGame_WebApi.Business;
using RouletteGame_WebApi.Models;

namespace RouletteGame_WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly AutenticacionContext _context;

        public UsuariosController(AutenticacionContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuarios>>> GetUsuario()
        {
            return await _context.Usuarios.ToListAsync();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuarios>> ConsultarUsuarioPorId(Guid id)
        {
            var Usuario = await _context.Usuarios.FindAsync(id);

            if (Usuario == null)
            {
                return NotFound();
            }

            return Usuario;
        }

        [HttpPost(Name = "ValidarAutenticacionUsuario")]
        public ActionResult<Usuarios> ValidarAutenticacionUsuario(Autenticacion autenticacion)
        {
            UsuarioBusiness UsuarioBusiness = new UsuarioBusiness(_context);
            Usuarios response = UsuarioBusiness.ValidarAutenticacionUsuario(autenticacion.usuario, autenticacion.clave);

            return response != null ? response : Content("No se encontro registro asociado"); ;
        }

        // POST: api/Usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost(Name = "CrearUsuario")]
        public ActionResult<Usuarios> CrearUsuario(PeticionUsuario Usuario)
        {
            UsuarioBusiness UsuarioBusiness = new UsuarioBusiness(_context);
            RequestResponse response = UsuarioBusiness.CrearUsuario(Usuario);

            if (response.SuccessFul == false)
            {
                return BadRequest(error: new { error = response.MessageError });
            }

            return Content("Registro Creado con xitoso");
        }

        [HttpPut(Name = "ActualizarUsuario")]
        public ActionResult<Usuarios> ActualizarUsuario(PeticionUsuario Usuario)
        {
            UsuarioBusiness UsuarioBusiness = new UsuarioBusiness(_context);
            RequestResponse response = UsuarioBusiness.CrearUsuario(Usuario);

            if (response.SuccessFul == false)
            {
                return BadRequest(error: new { error = response.MessageError });
            }

            return Content("Registro Actualizado con xito");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUsuario(Guid id)
        {
            var role = await _context.Roles.FindAsync(id);
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();

            return Content("Registro Actualizado con xito");
        }
    }
}
