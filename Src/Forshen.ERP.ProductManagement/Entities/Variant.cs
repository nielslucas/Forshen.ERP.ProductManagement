using Forshen.ERP.ProductManagement.Entities.Interfaces;

namespace Forshen.ERP.ProductManagement.Entities;

/// <summary>
/// 
/// </summary>
public class Variant : IEntity
{
    /// <summary>
    /// Identifier for the variant
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// A combination of the dimensions names and values
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Determines if it's a main variant
    /// <para>
    /// A variant is a main variant if it only made out of static values. Cause this is a base variant for example variants with THT that is dynamic.
    /// </para>
    /// </summary>
    public required bool IsMainVariant { get; set; }

    /// <summary>
    /// If this variant is not a main variant, this field references the main variant it is derived from.
    /// </summary>
    public int? MainVariantId { get; set; }
    
    /// <summary>
    /// The main variant from which this variant is derived, if applicable.
    /// </summary>
    public Variant? MainVariant { get; set; }
    
    /// <summary>
    /// The identifier to which product the variant belongs to.
    /// </summary>
    public int ProductId { get; set; }
    
    /// <summary>
    /// To which product the variant belongs to. 
    /// </summary>
    public Product Product { get; set; }
    
    /// <inheritdoc/>
    public DateTimeOffset CreatedAt { get; set; }
    
    /// <inheritdoc/>
    public DateTimeOffset? UpdatedAt { get; set; }
    
    /// <summary>
    /// The different kinds of dimensions together with its values for this variant
    /// </summary>
    public required ICollection<VariantDimensionValue> VariantDimensionValues { get; set; }

    public void UpdateName()
    {
        var name = new List<string>();

        foreach (var variantDimensionValue in VariantDimensionValues)
        {
            name.Add($"{variantDimensionValue.DimensionValue.Dimension.Name}: {variantDimensionValue.DimensionValue.Value}");
        }
        
        Name = string.Join(" | ", name);
    }
}