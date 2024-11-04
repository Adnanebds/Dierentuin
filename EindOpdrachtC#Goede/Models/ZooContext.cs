using Microsoft.EntityFrameworkCore;

namespace Dierentuin.Models
{
    public class ZooContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Enclosure> Enclosures { get; set; }
        public DbSet<Zoo> Zoos { get; set; }

        // Constructor accepting DbContextOptions
        public ZooContext(DbContextOptions<ZooContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // This can be left empty or used only when not configuring via dependency injection
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Dierentuin5;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your relationships and seeding here if necessary
        }
    }
}
    