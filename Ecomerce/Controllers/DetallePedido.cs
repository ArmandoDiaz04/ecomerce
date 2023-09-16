using Ecomerce.BD;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecomerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallePedido : ControllerBase
    {

        private readonly comercioDbContext _context;

        public DetallePedido(comercioDbContext context)
        {
            _context = context;
        }
    }
}
