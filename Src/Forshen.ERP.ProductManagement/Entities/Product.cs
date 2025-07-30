using Forshen.ERP.ProductManagement.Entities.Interfaces;

namespace Forshen.ERP.ProductManagement.Entities;

/// <summary>
/// Product that is used for sale
/// </summary>
public class Product : IEntity
{
    /// <inheritdoc/>
    public int Id { get; set; }
    
    /// <summary>
    /// The name of the product 
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Related dimensions for the product 
    /// </summary>
    public ICollection<Dimension> Dimensions { get; set; } = [];

    /// <summary>
    /// Related variants for the product
    /// </summary>
    public ICollection<Variant> Variants { get; set; } = [];
    
    /// <inheritdoc/>
    public DateTimeOffset CreatedAt { get; set; }
    
    /// <inheritdoc/>
    public DateTimeOffset? UpdatedAt { get; set; }
}