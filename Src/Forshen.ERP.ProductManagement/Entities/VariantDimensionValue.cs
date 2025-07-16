using Forshen.ERP.ProductManagement.Entities.Interfaces;

namespace Forshen.ERP.ProductManagement.Entities;

public class VariantDimensionValue :  IEntity
{
    public required int Id { get; set; }
    public required int VariantId { get; set; }
    public required Variant Variant { get; set; }
    
    public required int DimensionValueId { get; set; }
    public required DimensionValue DimensionValue { get; set; }
    public required DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}