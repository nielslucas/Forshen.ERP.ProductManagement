namespace Forshen.ERP.ProductManagement.Api.Models.Responses;

/// <summary>
/// Result set for pagination
/// </summary>
/// <typeparam name="T"></typeparam>
public record PaginationResponse<T>
{
    /// <summary>
    /// The resulting items from the paginated query.
    /// </summary>
    public required List<T> PageItems { get; init; }
    
    /// <summary>
    /// The total amount of items for the given query without pagination filters
    /// </summary>
    public required int TotalItemsCount { get; init; }
}