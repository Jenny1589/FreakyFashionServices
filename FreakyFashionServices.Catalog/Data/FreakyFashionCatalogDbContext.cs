using FreakyFashionServices.Catalog.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FreakyFashionServices.Catalog.Data
{
    public class FreakyFashionCatalogDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public FreakyFashionCatalogDbContext(DbContextOptions<FreakyFashionCatalogDbContext> options)
            : base(options) 
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .ToTable("Product")
                .Property(p => p.Id)
                .ValueGeneratedNever();
        }
    }
}
