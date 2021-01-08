using FreakyFashionServices.OrderConsole.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FreakyFashionServices.OrderConsole.Data
{
    public class FreakyFashionOrderDbContext : DbContext
    {
        private static readonly string _connectionString = "Server=localhost,11433;Database=FreakyFashionOrders;User Id=sa;Password=Secret#123";

        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order.OrderItem>()
                .ToTable("OrderItem")
                .Property(oi => oi.Id)
                .ValueGeneratedNever();

            modelBuilder.Entity<Order.OrderItem>()
                .HasKey(oi => new { oi.Id, oi.OrderId });

            modelBuilder.Entity<Order>()
                .ToTable("Order")
                .HasMany(o => o.Items)
                .WithOne()
                .HasForeignKey(oi => oi.OrderId);
        }       
    }
}
