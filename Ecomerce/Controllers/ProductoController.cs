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
        [Route("GetporId")]
        public ActionResult Getall([FromQuery] int? limit)
        {
            IQueryable<Producto> query = null;

            // Aplica el límite si se proporciona y es un valor positivo
            if (limit.HasValue && limit.Value > 0)
            {
                // Consulta la base de datos para obtener todos los productos
                query = _context.producto.Where(producto => producto.id_producto == limit);
            }

            // Ejecuta la consulta y obtiene los resultados
            List<Producto> productos = query.ToList();

            if (productos.Count == 0)
            {
                return NotFound();
            }

            return Ok(productos);
        }

        #endregion
        #region GET_ALL - GET
        [HttpGet]
        [Route("GetAll")]
        public ActionResult Get([FromQuery] string? q, [FromQuery] int? limit, [FromQuery] string? tipo)
        {
            // Consulta la base de datos para obtener todos los productos
            IQueryable<Producto> query = _context.producto;

            // Filtra por el tipo de producto si se proporciona (venta o Subasta)
            if (!string.IsNullOrEmpty(tipo))
            {
                // Aplicamos la parte de la consulta en memoria después de obtener los resultados de la base de datos.
                var productosFiltrados = query.ToList()
                    .Where(p => p.tipo_producto.Equals(tipo, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                // Filtra por el término 'q' si se proporciona
                if (!string.IsNullOrEmpty(q))
                {
                    productosFiltrados = productosFiltrados.Where(p => p.nombre.Contains(q)).ToList();
                }

                // Aplica el límite si se proporciona y es un valor positivo
                if (limit.HasValue && limit.Value > 0)
                {
                    productosFiltrados = productosFiltrados.Take(limit.Value).ToList();
                }

                return Ok(productosFiltrados);
            }

            // Filtra por el término 'q' si se proporciona
            if (!string.IsNullOrEmpty(q))
            {
                query = query.Where(p => p.nombre.Contains(q));
            }

            // Aplica el límite si se proporciona y es un valor positivo
            if (limit.HasValue && limit.Value > 0)
            {
                query = query.Take(limit.Value);
            }

            // Ejecuta la consulta y obtiene los resultados
            List<Producto> productos = query.ToList();

            if (productos.Count == 0)
            {
                return NotFound();
            }

            return Ok(productos);
        }
        #endregion
        #region GET_ALL subastas - GET
        [HttpGet]
        [Route("GetAllSB")]
        public ActionResult GetSb([FromQuery] string? q, [FromQuery] int? limit)
        {
            // Consulta la base de datos para obtener todos los productos
            IQueryable<Producto> query = _context.producto.Where(producto => producto.tipo_producto.ToUpper() == "SUBASTA");

            // Filtra por el término 'q' si se proporciona
            if (!string.IsNullOrEmpty(q))
            {
                query = query.Where(p => p.nombre.Contains(q));
            }

            // Aplica el límite si se proporciona y es un valor positivo
            if (limit.HasValue && limit.Value > 0)
            {
                query = query.Take(limit.Value);
            }

            // Ejecuta la consulta y obtiene los resultados
            List<Producto> productos = query.ToList();

            if (productos.Count == 0)
            {
                return NotFound();
            }

            return Ok(productos);
        }

        #endregion
        #region GET_ALL subastas abierta - GET
        [HttpGet]
        [Route("GetSBabiertas")]
        public ActionResult GetSubastasAbiertas()
        {
            // Filtra los productos por estado activo (por ejemplo, estado = 0 es abiertas)
            IQueryable<Producto> query = _context.producto.Where(p => p.estado == 0 && p.tipo_producto == "subasta");

            // Ejecuta la consulta y obtiene los resultados
            List<Producto> productos = query.ToList();

            if (productos.Count == 0)
            {
                return NotFound();
            }

            return Ok(productos);
        }

        #endregion
        #region GET_ALL subasta cerrada - GET
        [HttpGet]
        [Route("GetSBcerradas")]
        public ActionResult GetSubastasCerrada()
        {
            // Filtra los productos por estado activo (por ejemplo, estado = 0 es abiertas)
            IQueryable<Producto> query = _context.producto.Where(p => p.estado == 1 && p.tipo_producto == "subasta");

            // Ejecuta la consulta y obtiene los resultados
            List<Producto> productos = query.ToList();

            if (productos.Count == 0)
            {
                return NotFound();
            }

            return Ok(productos);
        }

        #endregion
        #region GET_ALL ventas abiertas - GET
        [HttpGet]
        [Route("GetVTabiertas")]
        public ActionResult GetVentasAbiertas()
        {
            // Filtra los productos por estado activo (por ejemplo, estado = 0 es abiertas)
            IQueryable<Producto> query = _context.producto.Where(p => p.estado == 0 && p.tipo_producto == "venta");

            // Ejecuta la consulta y obtiene los resultados
            List<Producto> productos = query.ToList();

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
                if (producto.tipo_producto == "Subasta")
                {
                    // Si el tipo de producto es "Subasta", establecer precio_subasta
                    producto.precio_subasta = producto.Precio;
                    producto.Precio = 0;
                }
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
        #region ACTUALIZAR-Subasta
        [HttpPut]
        [Route("ActualizarSubasta/{id}")]
        public IActionResult Actualizar(int id, [FromBody] PujaInputModel pujaInput)
        {
            Producto? producto = _context.producto.Find(id);

            if (producto == null)
            {
                return NotFound();
            }

            // Verifica si la puja es mayor que el precio actual de subasta antes de actualizar
            if (pujaInput.PrecioPuja > producto.precio_subasta)
            {
                // Actualiza el precio de subasta y cualquier otro campo necesario
                producto.precio_subasta = pujaInput.PrecioPuja;
                producto.id_usuario_ultima_puja = pujaInput.IdUsuario;

                _context.Entry(producto).State = EntityState.Modified;
                _context.SaveChanges();

                return Ok(producto);
            }
            else
            {
                return BadRequest("La puja debe ser mayor que el precio de subasta actual.");
            }
        }
        #endregion
        #region ACTUALIZAR-Subasta-estado
        [HttpPut]
        [Route("ActualizarEstadoSubasta/{id}")]
        public IActionResult ActualizarEstado(int id)
        {
            Producto? producto = _context.producto.Find(id);

            if (producto == null)
            {
                return NotFound();
            }

            // Verifica si la puja es mayor que el precio actual de subasta antes de actualizar
            if (producto.estado == 0)
            {
                // Actualiza el precio de subasta y cualquier otro campo necesario
                producto.estado = 1;

                _context.Entry(producto).State = EntityState.Modified;
                _context.SaveChanges();

                return Ok(producto);
            }
            else
            {
                return BadRequest("La puja debe ser mayor que el precio de subasta actual.");
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

            estado.nombre = producto.nombre;
            estado.Precio = producto.Precio;
            estado.precio_subasta = producto.precio_subasta;
            estado.imagen_url = producto.imagen_url;
            estado.descripcion = producto.descripcion;
            estado.id_categoria = producto.id_categoria;
            estado.estado = producto.estado;
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
    public class PujaInputModel
    {
        public decimal PrecioPuja { get; set; }
        public int IdUsuario { get; set; }
    }
}
