using Ecomerce.BD;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecomerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubastaController : ControllerBase
    {
        private readonly comercioDbContext _context;

        public SubastaController(comercioDbContext context)
        {
            _context = context;
        }
    }
}
