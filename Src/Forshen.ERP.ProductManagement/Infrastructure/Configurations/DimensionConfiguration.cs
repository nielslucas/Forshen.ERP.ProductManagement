using Forshen.ERP.ProductManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forshen.ERP.ProductManagement.Infrastructure.Configurations;

public class DimensionConfiguration : IEntityTypeConfiguration<Dimension>
{
    public void Configure(EntityTypeBuilder<Dimension> builder)
    {
        builder.ToTable("Dimensions");
        
        builder.HasKey(v => v.Id);
        
        builder.Property(p => p.Name)
            .HasMaxLength(128)
            .IsRequired();
    
        builder.Property(p => p.CreatedAt)
            .IsRequired();

        builder.Property(p => p.UpdatedAt);
        
        builder.HasMany(d => d.DimensionValues)
            .WithOne(v => v.Dimension)
            .HasForeignKey(v => v.DimensionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}