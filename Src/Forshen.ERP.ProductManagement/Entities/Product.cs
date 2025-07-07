using Forshen.ERP.ProductManagement.Entities.Interfaces;

namespace Forshen.ERP.ProductManagement.Entities;

/// <summary>
/// Product that is used for sale
/// </summary>
public class Product : IEntity, ITimestamps
{
    /// <inheritdoc/>
    public int Id { get; set; }
    
    /// <summary>
    /// The name of the product 
    /// </summary>
    public required string Name { get; set; }
    
    /// <inheritdoc/>
    public DateTimeOffset CreatedAt { get; set; }
    
    /// <inheritdoc/>
    public DateTimeOffset? UpdatedAt { get; set; }
}