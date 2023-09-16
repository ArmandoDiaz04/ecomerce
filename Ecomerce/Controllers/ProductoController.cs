using Ecomerce.BD;
using Ecomerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecomerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly comercioDbContext _context;

        public ProductoController(comercioDbContext context)
        {
            _context = context;
        }

        #region GET_ALL - GET
        [HttpGet]
        [Route("GetAll")]
        public ActionResult Get()
        {
            List<Producto> productos = _context.producto.ToList();

            if (productos.Count == 0)
            {
                return NotFound();
            }

            return Ok(productos);
        }

        #endregion

        #region GET_BY_ID - GET
        [HttpGet]
        [Route("GetById")]
        public ActionResult GetById(int id)
        {
            Producto? producto = _context.producto.Find(id);

            if (producto == null) return NotFound();

            return Ok(producto);
        }
        #endregion



        #region AGREGAR - POST
        [HttpPost]
        [Route("add")]
        public IActionResult crear([FromBody] Producto producto)
        {

            try
            {
                _context.producto.Add(producto);
                _context.SaveChanges();

                return Ok(producto);

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
        public IActionResult actualizar(int id, [FromBody] Producto producto)
        {
            Producto? estado = _context.producto.Find(id);

            if (estado == null)
            {
                return NotFound();
            }

            estado.Nombre = producto.Nombre;
            estado.Precio = producto.Precio;
            estado.precio_subasta = producto.precio_subasta;
            estado.imagen_url = producto.imagen_url;
            estado.Descripcion = producto.Descripcion;
            estado.id_categoria = producto.id_categoria;
            estado.Estado = producto.Estado;
            estado.fecha_inicio = producto.fecha_inicio;
            estado.fecha_final = producto.fecha_final;
            estado.tipo_producto = producto.tipo_producto;



            _context.Entry(estado).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(estado);

        }

        #endregion

        #region ELIMINAR - DELETE 
        [HttpDelete]
        [Route("deleteUsuario/{id}")]
        public void DeleteCarrito(int id)
        {
            var pedido = _context.Set<Pedido>().FirstOrDefault(u => u.id_pedido == id);
            if (pedido != null)
            {
                _context.Set<Pedido>().Remove(pedido);
                _context.SaveChanges();
            }
        }
        #endregion
    }
}
