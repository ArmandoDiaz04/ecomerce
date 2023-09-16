using Ecomerce.BD;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecomerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Pedido : ControllerBase
    {
        private readonly comercioDbContext _context;

        public Pedido(comercioDbContext context)
        {
            _context = context;
        }
    }
}
