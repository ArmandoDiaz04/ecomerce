using Ecomerce.BD;
using Ecomerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [HttpGet]
        [Route("logins")]
        public ActionResult GetLogin(String correo, String password)
        {
            Usuario? usuario = _context.usuarios.Where(u => u.Correo == correo && u.Password == password).FirstOrDefault();


            if (usuario == null) return NotFound();

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
