using Ecomerce.BD;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecomerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly comercioDbContext _context;

        public CategoriaController(comercioDbContext context)
        {
            _context = context;
        }
    }
}
