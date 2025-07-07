namespace Forshen.ERP.ProductManagement.Api.Endpoints.Movies;

[RouteGroupEndpoint(RouteGroupEndpointAttribute.Group.Movies)]
public class GetByIdEndpointMapper : IRouteGroupEndpoint
{
    public RouteGroupBuilder MapGroup(RouteGroupBuilder group)
    {
        group.MapGet("/{id:int}", (int id) =>
            {
                return Task.FromResult(id.ToString());
            })
            .WithName("GetMovieById");

        return group;
    }
}