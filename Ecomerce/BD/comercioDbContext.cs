using Microsoft.EntityFrameworkCore;

namespace Ecomerce.BD
{
    public class comercioDbContext : DbContext
    {
        public comercioDbContext(DbContextOptions<comercioDbContext> dbContext) : base(dbContext)
        {


        }

       //  public DbSet<modelo> variable { get; set; }

    }
}
