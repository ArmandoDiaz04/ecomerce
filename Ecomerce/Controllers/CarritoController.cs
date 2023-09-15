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

        public List<Carrito> GetAllCarritos()
        {
            return _context.Set<Carrito>().ToList();
        }

        public Carrito GetCarritoById(int id)
        {
            return _context.Set<Carrito>().FirstOrDefault(c => c.IdCarrito == id);
        }

        public void AddCarrito(Carrito carrito)
        {
            _context.Set<Carrito>().Add(carrito);
            _context.SaveChanges();
        }

        public void UpdateCarrito(Carrito carrito)
        {
            _context.Set<Carrito>().Update(carrito);
            _context.SaveChanges();
        }

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
