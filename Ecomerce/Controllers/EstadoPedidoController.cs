using Ecomerce.BD;
using Ecomerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecomerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoPedidoController : ControllerBase
    {
        private readonly comercioDbContext _context;

        public EstadoPedidoController(comercioDbContext context)
        {
            _context = context;
        }

        #region GET_ALL - GET
        [HttpGet]
        [Route("GetAll")]
        public ActionResult Get()
        {
            List<EstadoPedido> estadoPedidos = _context.estadopedido.ToList();

            if (estadoPedidos.Count == 0)
            {
                return NotFound();
            }

            return Ok(estadoPedidos);
        }

        #endregion

        #region GET_BY_ID - GET
        [HttpGet]
        [Route("GetById")]
        public ActionResult GetById(int id)
        {
            EstadoPedido? estadopedido = _context.estadopedido.Find(id);

            if (estadopedido == null) return NotFound();

            return Ok(estadopedido);
        }
        #endregion



        #region AGREGAR - POST
        [HttpPost]
        [Route("add")]
        public IActionResult crear([FromBody] EstadoPedido estadoPedido)
        {

            try
            {
                _context.estadopedido.Add(estadoPedido);
                _context.SaveChanges();

                return Ok(estadoPedido);

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
        public IActionResult actualizar(int id, [FromBody] EstadoPedido estadoPedido)
        {
            EstadoPedido? estado = _context.estadopedido.Find(id);

            if (estado == null)
            {
                return NotFound();
            }

            estado.Estado = estadoPedido.Estado;



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
            var estadopedido = _context.Set<EstadoPedido>().FirstOrDefault(u => u.id_estado_pedido == id);
            if (estadopedido != null)
            {
                _context.Set<EstadoPedido>().Remove(estadopedido);
                _context.SaveChanges();
            }
        }
        #endregion
    }
}
