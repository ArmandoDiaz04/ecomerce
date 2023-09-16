using Ecomerce.BD;
using Ecomerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        [Route("getAll")]
        public List<Carrito> GetAllCarritos()
        {
            return _context.Set<Carrito>().ToList();
        }
        [HttpGet]
        [Route("getbyID/(id)")]
        public Carrito GetCarritoById(int id)
        {
            return _context.Set<Carrito>().FirstOrDefault(c => c.IdCarrito == id);
        }
        [HttpPost]
        [Route("Add")]
        public void AddCarrito(Carrito carrito)
        {
            _context.Set<Carrito>().Add(carrito);
            _context.SaveChanges();
        }
        [HttpPut]
        [Route("actualizar(id)")]
        public void UpdateCarrito(Carrito carrito)
        {
            _context.Set<Carrito>().Update(carrito);
            _context.SaveChanges();
        }
        [HttpDelete]
        [Route("delete(id)")]
        public void DeleteCarrito(int id)
        {
            var carrito = _context.Set<Carrito>().FirstOrDefault(c => c.IdCarrito == id);
            if (carrito != null)
            {
                _context.Set<Carrito>().Remove(carrito);
                _context.SaveChanges();
            }
        }

    }
}
