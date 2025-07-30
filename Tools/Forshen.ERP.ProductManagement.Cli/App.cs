using Forshen.ERP.ProductManagement.Entities;
using Forshen.ERP.ProductManagement.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Forshen.ERP.ProductManagement.Cli;

public class App
{
    private readonly AppDbContext _dbContext;

    public App(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Run()
    {
        var dimensionColor = GetOrCreateDimension("Color");
        var dimensionColorYellow = GetOrCreateDimensionValue(dimensionColor, "Yellow");
        var dimensionColorRed = GetOrCreateDimensionValue(dimensionColor, "Red");
        
        var dimensionSize = GetOrCreateDimension("Size");
        var dimensionSize40 = GetOrCreateDimensionValue(dimensionSize, "40");
        var dimensionSize42 = GetOrCreateDimensionValue(dimensionSize, "42");
        
        var dimensionTHT = GetOrCreateDimension("THT", Dimension.DimensionType.Batch);
        var dimensionTHT20280730 = GetOrCreateDimensionValue(dimensionTHT, "2028-07-30");
        dimensionTHT20280730.Batch = new Batch
        {
            Number = "20280730",
            Description = "THT 2028-07-30",
            ExpireDate = new DateTimeOffset(2028, 7, 30, 0, 0, 0, TimeSpan.FromHours(2)),
            ProductionDate = new DateTimeOffset(2025, 7, 30, 18, 15, 0, TimeSpan.FromHours(2)),
        };

        var product = new Product
        {
            Name = "Schoen 1",
            Dimensions = [dimensionColor,  dimensionSize, dimensionTHT],
            Variants = [
                new Variant
                {
                    IsMainVariant = true,
                    VariantDimensionValues = [
                        new VariantDimensionValue
                        {
                            DimensionValue = dimensionColorYellow
                        },
                        new VariantDimensionValue
                        {
                            DimensionValue = dimensionSize40
                        }
                    ]
                },
                new Variant
                {
                    IsMainVariant = true,
                    VariantDimensionValues = [
                        new VariantDimensionValue
                        {
                            DimensionValue = dimensionColorRed
                        },
                        new VariantDimensionValue
                        {
                            DimensionValue = dimensionSize42
                        }
                    ]
                },
                new Variant
                {
                    IsMainVariant = false,
                    VariantDimensionValues = [
                        new VariantDimensionValue
                        {
                            DimensionValue = dimensionColorRed
                        },
                        new VariantDimensionValue
                        {
                            DimensionValue = dimensionSize42
                        },
                        new VariantDimensionValue
                        {
                            DimensionValue = dimensionTHT20280730
                        }
                    ]
                }
            ]
        };
        
        _dbContext.Products.Add(product);

        await _dbContext.SaveChangesAsync();

        var fullProductWithVariants = await _dbContext
            .Products
            .AsNoTracking()
            .Include(p => p.Variants)
            .ThenInclude(v => v.VariantDimensionValues)
            .ThenInclude(vdv => vdv.DimensionValue)
            .ThenInclude(dv => dv.Dimension)
            .Include(p => p.Variants)
            .ThenInclude(v => v.VariantDimensionValues)
            .ThenInclude(vdv => vdv.DimensionValue)
            .ThenInclude(dv => dv.Batch)
            .Where(p => p.Id == product.Id)
            .SingleAsync();

        Console.WriteLine("Product has these variants with dimensions:");
        foreach (var productVariant in fullProductWithVariants.Variants)
        {
            Console.WriteLine($"Variant: {productVariant.Name}");
            foreach (var variantDimensionValue in productVariant.VariantDimensionValues)
            {
                var variantValues = new List<string>
                {
                    $"{variantDimensionValue.DimensionValue.Dimension.Name}: {variantDimensionValue.DimensionValue.Value}"
                };

                var batch = variantDimensionValue.DimensionValue.Batch;

                if (batch is not null)
                {
                    variantValues.Add($"THT: {batch.ExpireDate}");
                }
                    
                Console.WriteLine(string.Join(", ", variantValues));
            }
        }
    }
    
    private Dimension GetOrCreateDimension(string name, Dimension.DimensionType type =  Dimension.DimensionType.Attribute)
    {
        var dimensionColor = _dbContext.Dimensions.SingleOrDefault(d => d.Name == name);

        if (dimensionColor == null)
        {
            dimensionColor = new Dimension
            {
                Name = name,
                Type = type
            };
    
            _dbContext.Dimensions.Add(dimensionColor);   
        }
        
        return dimensionColor;
    }
    
    private DimensionValue GetOrCreateDimensionValue(Dimension dimension, string value)
    {
        var dimensionColorYellow = _dbContext
            .DimensionValues
            .SingleOrDefault(d => d.DimensionId == dimension.Id && d.Value == value);

        if (dimensionColorYellow == null)
        {
            dimensionColorYellow = new DimensionValue
            {
                Dimension = dimension,
                Value = value,
            };
    
            _dbContext.DimensionValues.Add(dimensionColorYellow);   
        }
        
        return dimensionColorYellow;
    }
}