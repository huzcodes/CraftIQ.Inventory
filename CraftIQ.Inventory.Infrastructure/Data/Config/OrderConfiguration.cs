using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CraftIQ.Inventory.Core.Entities.Orders;
using CraftIQ.Inventory.Core.Entities.OrderDetails;

namespace CraftIQ.Inventory.Infrastructure.Data.Config
{

    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(p => p.Id)
                   .ValueGeneratedOnAdd();
        }
    }

    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.Property(p => p.Id)
                   .ValueGeneratedOnAdd();
        }
    }
}
