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
         public DbSet<DetalleSubasta> detalleSubasta { get; set; }
         public DbSet<DetalleVenta> detalleVenta { get; set; }
         public DbSet<EstadoSubasta> estadoSubasta { get; set; }
         public DbSet<Producto> producto { get; set; }
         public DbSet<Subasta> subasta { get; set; }
         public DbSet<Usuario> usuario { get; set; }
         public DbSet<Venta> venta { get; set; }

    }
}
