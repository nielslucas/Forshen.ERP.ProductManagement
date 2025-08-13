namespace Forshen.ERP.ProductManagement.Api.Endpoints.ProductDimension.Upsert;

/// <summary>
/// Request to attach or detach a dimension from a product
/// </summary>
public class UpsertEndpointRequest
{
    /// <summary>
    /// Identifier for the product
    /// </summary>
    public int ProductId { get; set; }
    
    /// <summary>
    /// Identifier for the dimension
    /// </summary>
    public int DimensionId { get; set; }
}