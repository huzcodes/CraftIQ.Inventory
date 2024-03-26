using CraftIQ.Inventory.Core.Domains.Common;
using CraftIQ.Inventory.Core.Domains.DB;
using CraftIQ.Inventory.Core.Domains.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace CraftIQInventory.Infrastructure.Persistence;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Category> categories { get; set; }
    public DbSet<Inventory> inventories { get; set; }
    public DbSet<Order> orders { get; set; }
    public DbSet<OrderDetail> orderDetails { get; set; }
    public DbSet<Product> products { get; set; }
    public DbSet<Transaction> transactions { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseEntity).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
            .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
        {
            entry.Entity.ModifiedOn = DateTime.Now;
            //entry.Entity.ModifiedBy = _userService.UserId;
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedOn = DateTime.Now;
                //entry.Entity.CreatedBy = _userService.UserId;
            }

            entry.Entity.Version = Guid.NewGuid();
        }

        return base.SaveChangesAsync(cancellationToken);
    }

}


