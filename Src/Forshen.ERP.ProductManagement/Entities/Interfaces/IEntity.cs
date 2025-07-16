namespace Forshen.ERP.ProductManagement.Entities.Interfaces;

public interface IEntity
{
    /// <summary>
    /// The unique identifier
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// When it was created
    /// </summary>
    public DateTimeOffset CreatedAt { get; set; }
    
    /// <summary>
    /// When it was last updated
    /// </summary>
    public DateTimeOffset? UpdatedAt { get; set; }
}