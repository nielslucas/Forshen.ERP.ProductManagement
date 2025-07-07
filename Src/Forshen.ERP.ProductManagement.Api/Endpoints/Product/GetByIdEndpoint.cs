namespace Forshen.ERP.ProductManagement.Api.Endpoints.Product;

[RouteGroupEndpoint(RouteGroupEndpointAttribute.Group.Products)]
public class GetByIdEndpoint : IRouteGroupEndpoint
{
    public RouteGroupBuilder MapGroup(RouteGroupBuilder group)
    {
        group.MapGet("/{id:int}", (int id) =>
            {
                return Task.FromResult(id.ToString());
            })
            .WithName("ProductGetById");
        
        return group;
    }
}