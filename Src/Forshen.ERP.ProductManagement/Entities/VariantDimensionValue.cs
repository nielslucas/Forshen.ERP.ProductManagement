using Forshen.ERP.ProductManagement.Entities.Interfaces;

namespace Forshen.ERP.ProductManagement.Entities;

public class VariantDimensionValue :  IEntity
{
    public int Id { get; set; }
    public int VariantId { get; set; }
    public Variant Variant { get; set; }
    
    public int DimensionValueId { get; set; }
    public required DimensionValue DimensionValue { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}