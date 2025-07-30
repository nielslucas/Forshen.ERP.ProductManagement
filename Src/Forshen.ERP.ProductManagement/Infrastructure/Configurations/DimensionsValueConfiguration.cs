using Forshen.ERP.ProductManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forshen.ERP.ProductManagement.Infrastructure.Configurations;

public class DimensionsValueConfiguration : IEntityTypeConfiguration<DimensionValue>
{
    public void Configure(EntityTypeBuilder<DimensionValue> builder)
    {
        builder.ToTable("DimensionValues");
        
        builder.HasKey(v => v.Id);
        
        builder.Property(p => p.DimensionId)
            .IsRequired();
        
        builder.Property(p => p.Value)
            .HasMaxLength(128)
            .IsRequired();
    
        builder.Property(p => p.CreatedAt)
            .IsRequired();

        builder.Property(p => p.UpdatedAt);
        
        builder.HasOne(v => v.Dimension)
            .WithMany(d => d.DimensionValues)
            .HasForeignKey(v => v.DimensionId);
        
        builder.HasOne(dv => dv.Batch)
            .WithOne(b => b.DimensionValue)
            .HasForeignKey<DimensionValue>(dv => dv.BatchId);
    }
}