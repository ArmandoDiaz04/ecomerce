using Ecomerce.BD;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecomerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoSubastaController : ControllerBase
    {
        private readonly comercioDbContext _context;

        public EstadoSubastaController(comercioDbContext context)
        {
            _context = context;
        }
    }
}
