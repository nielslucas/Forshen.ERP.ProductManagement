using Forshen.ERP.ProductManagement.Entities.Interfaces;

namespace Forshen.ERP.ProductManagement.Entities;

/// <summary>
/// Represents a batch (or lot) of produced items, typically resulting from a single production process.
/// Used for traceability, quality tracking, and expiry management.
/// </summary>
public class Batch : IEntity
{
    /// <summary>
    /// Unique identifier for the batch.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Unique batch number, typically human-readable.
    /// </summary>
    public required string Number { get; set; }

    /// <summary>
    /// Optional description or note about the batch.
    /// </summary>
    public required string Description { get; set; }

    /// <summary>
    /// Date when this batch was produced.
    /// </summary>
    public required DateTimeOffset ProductionDate { get; set; }

    /// <summary>
    /// Date until the batch is guaranteed to remain usable (e.g. THT).
    /// </summary>
    public required DateTimeOffset ExpireDate { get; set; }
    
    /// <summary>
    /// The dimension value that classifies this batch (e.g., a specific charge, serial number, or attribute).
    /// </summary>
    public DimensionValue DimensionValue { get; set; }

    /// <summary>
    /// When the batch record was created.
    /// </summary>
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;

    /// <summary>
    /// When the batch record was last updated.
    /// </summary>
    public DateTimeOffset? UpdatedAt { get; set; }
}