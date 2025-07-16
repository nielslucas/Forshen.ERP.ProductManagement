using Forshen.ERP.ProductManagement.Entities.Interfaces;

namespace Forshen.ERP.ProductManagement.Entities;

public class Dimension : IEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required DateTimeOffset CreatedAt { get; set; }
    public required DateTimeOffset? UpdatedAt { get; set; }
    public required ICollection<DimensionValue> DimensionValues { get; set; }
}