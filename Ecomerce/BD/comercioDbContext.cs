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
         public DbSet<Usuario> usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar las relaciones entre las entidades aquí
            modelBuilder.Entity<Carrito>()
                .HasOne(c => c.Usuario)
                .WithMany()
                .HasForeignKey(c => c.id_usuario);

            modelBuilder.Entity<Carrito>()
                .HasOne(c => c.Producto)
                .WithMany()
                .HasForeignKey(c => c.id_producto);
        }
    }
}
