using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CraftIQ.Inventory.Infrastructure.Data.Config
{

    public class OrderConfiguration : IEntityTypeConfiguration<Core.Entities.Order>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.Order> builder)
        {
            builder.Property(p => p.Id)
                   .ValueGeneratedOnAdd();
        }
    }

    public class OrderDetailConfiguration : IEntityTypeConfiguration<Core.Entities.OrderDetail>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.OrderDetail> builder)
        {
            builder.Property(p => p.Id)
                   .ValueGeneratedOnAdd();
        }
    }
}
