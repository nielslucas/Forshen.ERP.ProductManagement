namespace Forshen.ERP.ProductManagement.Api.Endpoints.Product;

public class ProductGroupBuilder : IGroupMapper
{
    public RouteGroupBuilder MapGroup(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("movies");
        this.MapGetByIdEndpoint(group);
        return group;
    }
}