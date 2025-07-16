using Forshen.ERP.ProductManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forshen.ERP.ProductManagement.Infrastructure.Configurations;

public class VariantConfiguration : IEntityTypeConfiguration<Variant>
{
    public void Configure(EntityTypeBuilder<Variant> builder)
    {
        builder.ToTable("Variants");

        builder.HasKey(v => v.Id);
    
        builder.Property(v => v.CreatedAt)
            .IsRequired();

        builder.Property(v => v.UpdatedAt);

        builder.HasMany(v => v.VariantDimensionValues)
            .WithOne(dv => dv.Variant) 
            .HasForeignKey(dv => dv.VariantId);
    }
}