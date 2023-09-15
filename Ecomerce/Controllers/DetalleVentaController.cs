using Ecomerce.BD;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecomerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleVentaController : ControllerBase
    {
        private readonly comercioDbContext _context;

        public DetalleVentaController(comercioDbContext context)
        {
            _context = context;
        }
    }
}
