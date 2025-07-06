namespace Forshen.ERP.ProductManagement.Api.Endpoints.Movies;

public class MoviesGroupBuilder : IGroupMapper
{
    public RouteGroupBuilder MapGroup(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("movies");
        this.MapGetByIdEndpoint(group);
        return group;
    }
}