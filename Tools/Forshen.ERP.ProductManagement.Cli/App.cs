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

        var product = new Product
        {
            Name = "Schoen 1",
            Dimensions = [dimensionColor,  dimensionSize],
            Variants = [
                new Variant
                {
                    MainVariant = true,
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
                    MainVariant = true,
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
            .Where(x => x.Id == product.Id)
            .SingleAsync();

        Console.WriteLine("Product has these variants with dimensions:");
        foreach (var productVariant in fullProductWithVariants.Variants)
        {
            Console.WriteLine($"Variant: {productVariant.Name}");
            foreach (var variantDimensionValue in productVariant.VariantDimensionValues)
            {
                Console.WriteLine($"{variantDimensionValue.DimensionValue.Dimension.Name}: {variantDimensionValue.DimensionValue.Value}");
            }
        }
    }
    
    private Dimension GetOrCreateDimension(string name)
    {
        var dimensionColor = _dbContext.Dimensions.SingleOrDefault(d => d.Name == name);

        if (dimensionColor == null)
        {
            dimensionColor = new Dimension
            {
                Name = name
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