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
        public ActionResult Get([FromQuery] string q)
        {
            if (string.IsNullOrEmpty(q))
            {
                // Si 'q' está vacío o nulo, retorna un error
                return BadRequest("El parámetro 'q' (id_usuario) es obligatorio.");
            }

            if (!int.TryParse(q, out int id_usuario))
            {
                // Si 'q' no es un número válido, retorna un error
                return BadRequest("El parámetro 'q' (id_usuario) debe ser un número entero válido.");
            }

            // Consulta la base de datos para obtener los carritos del usuario
            IQueryable<Carrito> query = _context.carrito.Where(c => c.id_usuario == id_usuario);

            // Ejecuta la consulta y obtiene los resultados
            List<Carrito> carritos = query.ToList();

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
        public IActionResult crear([FromBody] CarritoSimplificado carrito)
        {
            try
            {
                // Crea una nueva instancia de Carrito con los datos simplificados
                var carritoCompleto = new Carrito
                {
                    id_usuario = carrito.id_usuario,
                    id_producto = carrito.id_producto,
                    Cantidad = carrito.Cantidad,
                    fecha_agregado = DateTime.Now // Puedes establecer la fecha actual aquí
                };

                _context.carrito.Add(carritoCompleto);
                _context.SaveChanges();

                return Ok(carritoCompleto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion


        #region Carrito con nombre

        [HttpGet]
        [Route("Getbyname")]
        public ActionResult Getbyname([FromQuery] string q)
        {
            if (string.IsNullOrEmpty(q) || !int.TryParse(q, out int id_usuario))
            {
                return BadRequest("El parámetro 'q' (id_usuario) es obligatorio y debe ser un número entero válido.");
            }

            var carritos = _context.carrito
                .Where(c => c.id_usuario == id_usuario)
                .Include(c => c.Usuario)  // Incluye la información del usuario
                .Include(c => c.Producto) // Incluye la información del producto
                .ToList();

            if (carritos.Count == 0)
            {
                return NotFound();
            }

            // Proyecta los resultados para mostrar precio unitario y total
            var resultado = carritos.Select(c => new
            {
                IdCarrito = c.id_carrito,
                IdProducto = c.Producto.id_producto, // Agrega el id_producto
                NombreUsuario = c.Usuario.nombre_usuario,
                NombreProducto = c.Producto.nombre,
                PrecioUnitario = c.Producto.Precio / c.Cantidad, // Precio unitario
                Total = c.Producto.Precio, // Total (precio del producto)
                Cantidad = c.Cantidad,
                FechaAgregado = c.fecha_agregado,
                precioSubasta = c.Producto.precio_subasta,
                tipoProducto = c.Producto.tipo_producto,
                id_ultimaPuja = c.Producto.id_usuario_ultima_puja
            });

            return Ok(resultado);
        }

        #endregion


        // hola cambios



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
        [Route("deleteCarrito/{id}")]
        public IActionResult DeleteCarrito(int id)
        {
            var carrito = _context.carrito.FirstOrDefault(c => c.id_carrito == id);
            if (carrito != null)
            {
                _context.carrito.Remove(carrito);
                _context.SaveChanges();
                return Ok(new { message = "Carrito eliminado exitosamente." });
            }
            else
            {
                return NotFound(new { message = "Carrito no encontrado." });
            }
        }


        #endregion

        #region ELIMINAR - DELETE- Q

        [HttpDelete]
        [Route("deleteCarritoByUsuario/{q}")]
        public IActionResult DeleteCarritoByUsuario(int q)
        {
            var carritos = _context.carrito.Where(c => c.id_usuario == q).ToList();

            if (carritos.Count > 0)
            {
                foreach (var carrito in carritos)
                {
                    _context.carrito.Remove(carrito);
                }

                _context.SaveChanges();
                return Ok(new { message = "Carritos eliminados exitosamente para el usuario con id " + q });
            }
            else
            {
                return NotFound(new { message = "No se encontraron carritos para el usuario con id " + q });
            }
        }

#endregion
    }
}
