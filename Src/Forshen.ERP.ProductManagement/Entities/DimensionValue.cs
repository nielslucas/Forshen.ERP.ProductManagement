using Forshen.ERP.ProductManagement.Entities.Interfaces;

namespace Forshen.ERP.ProductManagement.Entities;

public class DimensionValue : IEntity, ITimestamps
{
    public int Id { get; set; }
    public int DimensionId { get; set; }
    public Dimension Dimension { get; set; } = null!;
    public string Value { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}