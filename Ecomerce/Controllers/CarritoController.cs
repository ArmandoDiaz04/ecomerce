using Ecomerce.BD;
using Ecomerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecomerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class CarritoController : ControllerBase
    {
        private readonly comercioDbContext _context;

        public CarritoController(comercioDbContext context)
        {
            _context = context;
        }

        #region GET_ALL - GET
        [HttpGet]
        [Route("GetAll")]
        public ActionResult Get()
        {
            List<Carrito> carritos = _context.carrito.ToList();

            if (carritos.Count == 0)
            {
                return NotFound();
            }

            return Ok(carritos);
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
        public IActionResult crear([FromBody] Carrito carrito)
        {

            try
            {
                _context.carrito.Add(carrito);
                _context.SaveChanges();

                return Ok(carrito);

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
        public IActionResult actualizar(int id, [FromBody] Carrito carrito)
        {
            Carrito? carritosO = _context.carrito.Find(id);

            if (carritosO == null)
            {
                return NotFound();
            }

            carritosO.id_usuario = carrito.id_usuario;
            carritosO.id_producto = carrito.id_producto;
            carritosO.Cantidad = carrito.Cantidad;
            carritosO.fecha_agregado = carrito.fecha_agregado;


            _context.Entry(carritosO).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(carritosO);

        }

        #endregion

        #region ELIMINAR - DELETE 
        [HttpDelete]
        [Route("deleteUsuario/{id}")]
        public void DeleteCarrito(int id)
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
