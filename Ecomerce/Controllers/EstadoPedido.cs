using Ecomerce.BD;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecomerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoPedido : ControllerBase
    {
        private readonly comercioDbContext _context;

        public EstadoPedido(comercioDbContext context)
        {
            _context = context;
        }
    }
}
