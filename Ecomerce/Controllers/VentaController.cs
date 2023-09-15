using Ecomerce.BD;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecomerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly comercioDbContext _context;

        public VentaController(comercioDbContext context)
        {
            _context = context;
        }
    }
}
