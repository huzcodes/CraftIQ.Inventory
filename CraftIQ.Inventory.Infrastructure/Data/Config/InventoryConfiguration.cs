using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CraftIQ.Inventory.Infrastructure.Data.Config
{
    public class InventoryConfiguration : IEntityTypeConfiguration<Core.Entities.Inventories.Inventory>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.Inventories.Inventory> builder)
        {
            builder.Property(p => p.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(p => p.Location)
                   .HasMaxLength(200);

            builder.Property(p => p.Name)
                   .HasMaxLength(50);
        }
    }
}
