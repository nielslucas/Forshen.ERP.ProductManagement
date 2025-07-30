using Forshen.ERP.ProductManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forshen.ERP.ProductManagement.Infrastructure.Configurations;

public class BatchConfiguration : IEntityTypeConfiguration<Batch>
{
    public void Configure(EntityTypeBuilder<Batch> builder)
    {
        builder
            .HasOne(b => b.DimensionValue)
            .WithOne(dv => dv.Batch)
            .HasForeignKey<DimensionValue>(dv => dv.BatchId);
    }
}