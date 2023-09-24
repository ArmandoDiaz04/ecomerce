using Ecomerce.BD;
using Ecomerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecomerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallePedidoController : ControllerBase
    {

        private readonly comercioDbContext _context;

        public DetallePedidoController(comercioDbContext context)
        {
            _context = context;
        }

        #region GET_ALL - GET
        [HttpGet]
        [Route("GetAll")]
        public ActionResult Get()
        {
            List<DetallePedido> detallePedidos = _context.detalle_pedido.ToList();

            if (detallePedidos.Count == 0)
            {
                return NotFound();
            }

            return Ok(detallePedidos);
        }

        #endregion

        #region GET_BY_ID - GET
        [HttpGet]
        [Route("GetById")]
        public ActionResult GetById(int id)
        {
            DetallePedido? detalle = _context.detalle_pedido.Find(id);

            if (detalle == null) return NotFound();

            return Ok(detalle);
        }
        #endregion

        #region AGREGAR - POST
        [HttpPost]
        [Route("add")]
        public IActionResult crear([FromBody] DetallePedidoInputModel inputModel)
        {
            try
            {
                // Verificar si los datos son válidos antes de agregarlos
                if (inputModel == null || inputModel.id_producto <= 0 || inputModel.id_pedido <= 0 || inputModel.cantidad <= 0)
                {
                    return BadRequest("Los datos no son válidos.");
                }

                // Crear un objeto DetallePedido con los valores recibidos
                var detalle = new DetallePedido
                {
                    id_producto = inputModel.id_producto,
                    id_pedido = inputModel.id_pedido,
                    cantidad = inputModel.cantidad
                };

                _context.detalle_pedido.Add(detalle);
                _context.SaveChanges();

                return Ok(detalle);
            }
            catch (Exception ex)
            {
                // Registra el error para depuración
                Console.WriteLine(ex.ToString());
                return BadRequest("Ocurrió un error al guardar los datos.");
            }
        }
        #endregion


        #region ACTUALIZAR - POST

        [HttpPut]
        [Route("Actualizar/{id}")]
        public IActionResult actualizar(int id, [FromBody] DetallePedido detallePedido)
        {
            DetallePedido? detalle = _context.detalle_pedido.Find(id);

            if (detalle == null)
            {
                return NotFound();
            }

            detalle.id_producto = detallePedido.id_producto;
            detalle.id_pedido = detallePedido.id_pedido;
            detalle.cantidad = detallePedido.cantidad;



            _context.Entry(detalle).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(detalle);

        }

        #endregion

        #region ELIMINAR - DELETE 
        [HttpDelete]
        [Route("deleteUsuario/{id}")]
        public void DeleteCarrito(int id)
        {
            var detalle = _context.Set<DetallePedido>().FirstOrDefault(u => u.id_detalle == id);
            if (detalle != null)
            {
                _context.Set<DetallePedido>().Remove(detalle);
                _context.SaveChanges();
            }
        }
        #endregion
    }
    public class DetallePedidoInputModel
    {
        public int? id_producto { get; set; }
        public int? id_pedido { get; set; }
        public int cantidad { get; set; }
    }
}
