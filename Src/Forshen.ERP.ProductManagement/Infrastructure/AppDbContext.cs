using Forshen.ERP.ProductManagement.Entities;
using Microsoft.EntityFrameworkCore;

namespace Forshen.ERP.ProductManagement.Infrastructure;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
    public DbSet<Dimension> Dimensions { get; set; }
    public DbSet<DimensionValue> DimensionValues { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Variant> Variants { get; set; }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }
    
    public override int SaveChanges()
    {
        SaveChangesAdjustments();
        return base.SaveChanges();
    }
    
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SaveChangesAdjustments();
        return await base.SaveChangesAsync(cancellationToken);
    }

    private void SaveChangesAdjustments()
    {
        AdjustVariant();
        return;

        void AdjustVariant()
        {
            foreach (var entry in ChangeTracker.Entries<Variant>())
            {
                // Check if the entity itself was added or modified
                var isEntityChanged = entry.State is EntityState.Added or EntityState.Modified;
            
                // Check if the VariantDimensionValues collection was modified (items added/removed)
                var areDimensionsChanged = entry.Collections
                    .Any(c => c.Metadata.Name == nameof(Variant.VariantDimensionValues) && c.IsModified);
            
                // If no type of change is detected, don't do anything
                if (!isEntityChanged && !areDimensionsChanged)
                    continue;

                entry.Entity.UpdateName();
            }
        }
    }
}