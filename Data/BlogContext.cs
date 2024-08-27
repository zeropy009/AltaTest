using AltaTest.Model;
using Microsoft.EntityFrameworkCore;

namespace AltaTest.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options)
            : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Points> Points { get; set; }
    }
}
