using CraftIQ.Inventory.Core.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CraftIQ.Inventory.Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(p => p._ProductId)
                    .IsRequired();

            builder.Property(p => p.Name)
                   .HasMaxLength(50);

            builder.Property(p => p.Description)
                   .HasMaxLength(200);
        }
    }
}
