using Ecomerce.BD;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecomerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleSubastaController : ControllerBase
    {
        private readonly comercioDbContext _context;

        public DetalleSubastaController(comercioDbContext context)
        {
            _context = context;
        }
    }
}
