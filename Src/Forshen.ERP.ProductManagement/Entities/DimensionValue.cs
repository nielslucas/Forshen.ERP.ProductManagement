using Forshen.ERP.ProductManagement.Entities.Interfaces;

namespace Forshen.ERP.ProductManagement.Entities;

public class DimensionValue : IEntity
{
    public required int Id { get; set; }
    public required int DimensionId { get; set; }
    public required Dimension Dimension { get; set; }
    public required string Value { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}