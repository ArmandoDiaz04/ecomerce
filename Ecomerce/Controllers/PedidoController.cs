using Ecomerce.BD;
using Ecomerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecomerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly comercioDbContext _context;

        public PedidoController(comercioDbContext context)
        {
            _context = context;
        }

        #region GET_ALL - GET
        [HttpGet]
        [Route("GetAll")]
        public ActionResult Get()
        {
            List<Pedido> pedidos = _context.pedido.ToList();

            if (pedidos.Count == 0)
            {
                return NotFound();
            }

            return Ok(pedidos);
        }

        #endregion

        #region GET_BY_ID - GET
        [HttpGet]
        [Route("GetById")]
        public ActionResult GetById(int id)
        {
            Pedido? pedido = _context.pedido.Find(id);

            if (pedido == null) return NotFound();

            return Ok(pedido);
        }
        #endregion



        #region AGREGAR - POST
        [HttpPost]
        [Route("add")]
        public IActionResult crear([FromBody] Pedido pedido)
        {

            try
            {
                _context.pedido.Add(pedido);
                _context.SaveChanges();

                return Ok(pedido);

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
        public IActionResult actualizar(int id, [FromBody] Pedido pedido)
        {
            Pedido? estado = _context.pedido.Find(id);

            if (estado == null)
            {
                return NotFound();
            }

            estado.total_pagar = pedido.total_pagar;



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
