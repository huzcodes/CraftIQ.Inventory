using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CraftIQ.Inventory.Infrastructure.Data.Config
{
    public class InventoryConfiguration : IEntityTypeConfiguration<Core.Entities.Inventory>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.Inventory> builder)
        {
            builder.Property(p => p.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(p => p.Location)
                   .HasMaxLength(200);
        }
    }
}
