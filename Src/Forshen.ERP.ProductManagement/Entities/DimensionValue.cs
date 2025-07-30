using Forshen.ERP.ProductManagement.Entities.Interfaces;

namespace Forshen.ERP.ProductManagement.Entities;

/// <summary>
/// Represents a specific value for a given <see cref="Dimension"/>, 
/// such as "Red" for the "Color" dimension or "42" for the "Size" dimension.
/// </summary>
public class DimensionValue : IEntity
{
    /// <summary>
    /// The unique identifier of the dimension value.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// The identifier of the related <see cref="Dimension"/>.
    /// </summary>
    public int DimensionId { get; set; }
    
    /// <summary>
    /// The dimension this value belongs to.
    /// </summary>
    public required Dimension Dimension { get; set; }
    
    /// <summary>
    /// The actual value or option for the dimension (e.g., "Red", "42", or "THT 2025-01-01").
    /// </summary>
    public required string Value { get; set; }
    
    /// <summary>
    /// The optional identifier of the batch (lot) this dimension value is associated with.
    /// </summary>
    public int? BatchId { get; set; }

    /// <summary>
    /// The batch (lot) this dimension value is associated with, if applicable.
    /// </summary>
    public Batch? Batch { get; set; }
    
    /// <summary>
    /// The timestamp when this value was created.
    /// </summary>
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
    
    /// <summary>
    /// The timestamp when this value was last updated, if applicable.
    /// </summary>
    public DateTimeOffset? UpdatedAt { get; set; }
}