namespace Forshen.ERP.ProductManagement.Api.Endpoints.Product;

public static class GetByIdEndpoint
{
    public static void MapGetByIdEndpoint(this ProductGroupBuilder moviesGroupBuilder, RouteGroupBuilder routeGroupBuilder)
    {
        routeGroupBuilder.MapGet("/{id:int}", (int id) =>
            {
                return Task.FromResult(id.ToString());
            })
            .WithName("GetProductById");
    }
}