using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CraftIQ.Inventory.Infrastructure.Data.Config;

public class InventoryConfiguration : IEntityTypeConfiguration<Core.Domains.DB.Inventory>
{
    public void Configure(EntityTypeBuilder<Core.Domains.DB.Inventory> builder)
    {
        builder.Property(p => p.Location)
                .HasMaxLength(200);
    }
}

