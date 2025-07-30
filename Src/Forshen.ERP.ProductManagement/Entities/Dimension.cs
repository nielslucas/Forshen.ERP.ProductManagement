using Forshen.ERP.ProductManagement.Entities.Interfaces;

namespace Forshen.ERP.ProductManagement.Entities;

/// <summary>
/// Represents a dimension that describes a specific characteristic of a product, 
/// such as its color, size, or any other distinguishing attribute.
/// </summary>
public class Dimension : IEntity
{
    /// <summary>
    /// The unique identifier of the dimension.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// The name of the dimension (e.g., "Color", "Size").
    /// </summary>
    public required string Name { get; set; }
    
    /// <summary>
    /// The type of the dimension, indicating how it is used (e.g., attribute, charge, serial number).
    /// </summary>
    public required DimensionType Type { get; set; }
    
    /// <summary>
    /// The timestamp when the dimension was created.
    /// </summary>
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
    
    /// <summary>
    /// The timestamp when the dimension was last updated, if applicable.
    /// </summary>
    public DateTimeOffset? UpdatedAt { get; set; }
    
    /// <summary>
    /// The possible values associated with this dimension (e.g., "Red", "Blue", "Small", "Large").
    /// </summary>
    public ICollection<DimensionValue> DimensionValues { get; set; } = [];
    
    /// <summary>
    /// The products that use this dimension.
    /// </summary>
    public ICollection<Product> Products { get; set; } = [];
    
    /// <summary>
    /// Defines the type of a dimension.
    /// </summary>
    public enum DimensionType
    {
        /// <summary>
        /// A basic attribute of the product (e.g., color, size).
        /// </summary>
        Attribute,
        
        /// <summary>
        /// A batch-related dimension, such as THT, expiry date, or production lot.
        /// Commonly called "Charge" in German ERP terminology.
        /// </summary>
        Batch,
        
        /// <summary>
        /// A unique identifier or serial value, often used for traceability.
        /// </summary>
        SerialNumber
    }
}