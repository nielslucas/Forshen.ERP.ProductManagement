using Forshen.ERP.ProductManagement.Infrastructure;
using Forshen.ERP.ProductManagement.Api.Models.Responses;
using Microsoft.EntityFrameworkCore;

namespace Forshen.ERP.ProductManagement.Api.Endpoints.Product.GetById;

[RouteGroupEndpoint(RouteGroupEndpointAttribute.Group.Products)]
public class GetByIdEndpoint : IRouteGroupEndpoint
{
    public RouteGroupBuilder MapGroup(RouteGroupBuilder group)
    {
        group.MapGet("/{id}", async (AppDbContext db, int id) =>
            {
                var product = await db.Products.SingleOrDefaultAsync(x => x.Id == id);

                return product == null ? Results.NoContent() : Results.Ok(product);;
            })
            .WithName("ProductGetById")
            .Produces<PaginationResponse<Entities.Product>>(StatusCodes.Status200OK)
            .WithSummary("Get product by its id.")
            .WithDescription("Returns product.");
        
        return group;
    }
}