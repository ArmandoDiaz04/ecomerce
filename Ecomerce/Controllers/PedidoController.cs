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
            List<Pedido> pedidos = _context.pedidos.ToList();

            if (pedidos.Count == 0)
            {
                return NotFound();
            }

            return Ok(pedidos);
        }

        #endregion
        #region GET_ALL - Datos Unidos
        [HttpGet]
        [Route("GetAllscc")]
        public ActionResult GetDatosUnidos(int idUsuario)
        {
            // Realiza una consulta LINQ para obtener los datos necesarios
            var datosUnidos = (from p in _context.pedidos
                               join d in _context.detalle_pedido on p.id_pedido equals d.id_pedido
                               join u in _context.usuarios on p.id_usuario equals u.id_usuario
                               where p.id_usuario == idUsuario
                               select new
                               {
                                   Pedido = p,
                                   DetallesPedido = d,
                                   Usuario = u
                               }).ToList();

            if (datosUnidos.Count == 0)
            {
                return NotFound();
            }

            return Ok(datosUnidos);
        }



        #endregion


        #region GET_BY_ID - GET
        [HttpGet]
        [Route("GetById")]
        public ActionResult GetById(int id)
        {
            Pedido? pedido = _context.pedidos.Find(id);

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
                // Agregar un punto de interrupción aquí o agregar un registro
                _context.pedidos.Add(pedido);
                _context.SaveChanges();

                // Retornar el ID del pedido recién insertado
                return Ok(new { id_pedido = pedido.id_pedido });
            }
            catch (Exception ex)
            {
                // Agregar un punto de interrupción aquí o agregar un registro
                return BadRequest(ex.Message);
            }
        }
        #endregion



        //#region AGREGAR - POST
        //[HttpPost]
        //[Route("add")]
        //public IActionResult crear([FromBody] Pedido pedido)
        //{
        //    try
        //    {
        //        // Agregar un punto de interrupción aquí o agregar un registro
        //        _context.pedidos.Add(pedido);
        //        _context.SaveChanges();

        //        return Ok(pedido);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Agregar un punto de interrupción aquí o agregar un registro
        //        return BadRequest(ex.Message);
        //    }
        //}
        //#endregion

        #region ACTUALIZAR - POST

        [HttpPut]
        [Route("Actualizar/{id}")]
        public IActionResult actualizar(int id, [FromBody] Pedido pedido)
        {
            Pedido? estado = _context.pedidos.Find(id);

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
    public class PedidoInputModel
    {
        public double total_pagar { get; set; }
        public DateTime fecha_pedido { get; set; }
        public int id_estado_pedido { get; set; }
        public int id_usuario { get; set; }
        public string Ubicacion { get; set; } // Capitalize 'Ubicacion'
    }
    public class FacturaData
    {
        public object Pedido { get; set; }
        public object DetallesPedido { get; set; }
        public object Usuario { get; set; }
    }
}
