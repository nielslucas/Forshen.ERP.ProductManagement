using Forshen.ERP.ProductManagement.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Forshen.ERP.ProductManagement.Api.Endpoints.Product;

[RouteGroupEndpoint(RouteGroupEndpointAttribute.Group.Products)]
public class GetAllEndpoint : IRouteGroupEndpoint
{
    public RouteGroupBuilder MapGroup(RouteGroupBuilder group)
    {
        group.MapGet("", async (AppDbContext db) =>
            {
                return await db.Products.ToListAsync();
            })
            .WithName("Product");
        
        return group;
    }
}