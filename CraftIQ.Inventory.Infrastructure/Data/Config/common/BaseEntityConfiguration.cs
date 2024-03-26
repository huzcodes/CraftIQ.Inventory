using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CraftIQ.Inventory.Core.Domains.Common;

namespace CraftIQ.Inventory.Infrastructure.Data.Config.common;

public class BaseEntityConfiguration : IEntityTypeConfiguration<BaseEntity>
{
    public void Configure(EntityTypeBuilder<BaseEntity> builder)
    {
        builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

        builder.Property(p => p.Version)
                .IsConcurrencyToken();
    }
}

