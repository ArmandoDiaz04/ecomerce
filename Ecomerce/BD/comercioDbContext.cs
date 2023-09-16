using Ecomerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecomerce.BD
{
    public class comercioDbContext : DbContext
    {
        public comercioDbContext(DbContextOptions<comercioDbContext> dbContext) : base(dbContext)
        {


        }

         public DbSet<Carrito> carrito { get; set; }
         public DbSet<Categoria> categoria { get; set; }
        public DbSet<DetallePedido> detallepedido { get; set; }
        public DbSet<EstadoPedido> estadopedido { get; set; }
        public DbSet<Pedido> pedido { get; set; }
        public DbSet<Producto> producto { get; set; }
         public DbSet<Usuario> usuario { get; set; }

    }
}
