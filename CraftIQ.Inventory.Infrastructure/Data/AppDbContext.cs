using CraftIQ.Inventory.Core.Entities;
using CraftIQ.Inventory.Core.Entities.Categories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CraftIQ.Inventory.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // db sets lands here
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Core.Entities.Inventory> Inventories => Set<Core.Entities.Inventory>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderDetail> OrderDetails => Set<OrderDetail>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Transaction> Transactions => Set<Transaction>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
