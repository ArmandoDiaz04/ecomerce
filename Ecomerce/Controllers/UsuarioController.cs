using Ecomerce.BD;
using Ecomerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace Ecomerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly comercioDbContext _context;

        public UsuarioController(comercioDbContext context)
        {
            _context = context;
        }


        #region GET_ALL - GET
        [HttpGet]
        [Route("GetAll")]
        public ActionResult Get()
        {
            List<Usuario> listadoEquipos = _context.usuarios.ToList();

            if (listadoEquipos.Count == 0)
            {
                return NotFound();
            }

            return Ok(listadoEquipos);
        }


        #endregion


        #region Login
        [HttpPost("login")]
        public ActionResult GetLogin([FromBody] UsuarioLoginRequest request)
        {
            if (request == null)
            {
                return BadRequest("Los datos de inicio de sesión son nulos o incorrectos.");
            }

            Usuario usuario = _context.usuarios.FirstOrDefault(u => u.Correo == request.Correo && u.Password == request.Password);

            if (usuario == null)
            {
                return NotFound("No se encontró un usuario con las credenciales proporcionadas.");
            }

            // Aquí puedes devolver el objeto usuario encontrado
            return Ok(usuario);
        }
        #endregion



        #region GET_BY_ID - GET
        [HttpGet]
        [Route("GetById")]
        public ActionResult GetById(int id)
        {
            Usuario? usuario = _context.usuarios.Find(id);

            if (usuario == null) return NotFound();

            return Ok(usuario);
        }
        #endregion

        

        #region AGREGAR - POST
        [HttpPost]
        [Route("add")]
        public IActionResult crear([FromBody] Usuario usuario)
        {

            try
            {
                _context.usuarios.Add(usuario);
                _context.SaveChanges();

                return Ok(usuario);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        #endregion

        #region ACTUALIZAR - POST

        [HttpPut]
        [Route("Actualizar/{id}")]
        public IActionResult actualizar(int id, [FromBody] Usuario usuario)
        {
            Usuario? usuarios = _context.usuarios.Find(id);

            if (usuarios == null)
            {
                return NotFound();
            }

            usuarios.nombre_usuario = usuario.nombre_usuario;
            usuarios.apellido_usuario = usuario.apellido_usuario;
            usuarios.Correo = usuario.Correo;
            usuarios.Telefono = usuario.Telefono;
            usuarios.Direccion = usuario.Direccion;
            usuarios.Password = usuario.Password;

            _context.Entry(usuarios).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(usuarios);

        }

        #endregion

        #region ELIMINAR - DELETE 
        [HttpDelete]
        [Route("deleteUsuario/{id}")]
        public void DeleteUsuario(int id)
        {
            var usuario = _context.Set<Usuario>().FirstOrDefault(u => u.id_usuario == id);
            if (usuario != null)
            {
                _context.Set<Usuario>().Remove(usuario);
                _context.SaveChanges();
            }
        }
        #endregion


    }
}
