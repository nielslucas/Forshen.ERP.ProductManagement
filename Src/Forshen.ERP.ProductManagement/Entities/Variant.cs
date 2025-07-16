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
    public required int Id { get; set; }

    /// <inheritdoc/>
    public DateTimeOffset CreatedAt { get; set; }
    
    /// <inheritdoc/>
    public DateTimeOffset? UpdatedAt { get; set; }

    /// <summary>
    /// Determines if it's a main variant
    /// <para>
    /// A variant is a main variant if it only made out of static values. Cause this is a base variant for example variants with THT that is dynamic.
    /// </para>
    /// </summary>
    public required bool MainVariant { get; set; }
    
    /// <summary>
    /// To which product the variant belongs to. 
    /// </summary>
    public required Product Product { get; set; }
    
    /// <summary>
    /// The different kinds of dimensions together with its values for this variant
    /// </summary>
    public required ICollection<VariantDimensionValue> VariantDimensionValues { get; set; }
}