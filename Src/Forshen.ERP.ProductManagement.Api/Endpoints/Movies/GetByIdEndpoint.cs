namespace Forshen.ERP.ProductManagement.Api.Endpoints.Movies;

public static class GetByIdEndpointMapper
{
    public static void MapGetByIdEndpoint(this MoviesGroupBuilder moviesGroupBuilder, RouteGroupBuilder routeGroupBuilder)
    {
        routeGroupBuilder.MapGet("/{id:int}", (int id) =>
            {
                return Task.FromResult(id.ToString());
            })
            .WithName("GetMovieById");
    }
}