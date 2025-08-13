using Forshen.ERP.ProductManagement.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Forshen.ERP.ProductManagement.Api.Endpoints.ProductDimension.Upsert;

[RouteGroupEndpoint(RouteGroupEndpointAttribute.Group.ProductDimensions)]
public class UpsertEndpoint : IRouteGroupEndpoint
{
    public RouteGroupBuilder MapGroup(RouteGroupBuilder group)
    {
        group.MapPost("", async (UpsertEndpointRequest endpointRequest, AppDbContext db) =>
            {
                var product = await db
                    .Products
                    .Include(x => x.Dimensions)
                    .SingleAsync(x => x.Id == endpointRequest.ProductId);
                
                var existingDimension = product.Dimensions.Any(x => x.Id == endpointRequest.DimensionId);

                if (existingDimension)
                {
                    return Results.Conflict("This dimensions is already attached tot he product");
                }
                
                var dimensionsToAttach = await db.Dimensions.SingleAsync(x => x.Id == endpointRequest.DimensionId);
                
                product.Dimensions.Add(dimensionsToAttach);
                
                await db.SaveChangesAsync();
                
                return Results.NoContent();
            })
            .WithName("ProductDimensionAttachDimensions")
            //.Produces<PaginationResponse<Entities.Product>>(StatusCodes.Status200OK)
            //.WithSummary("Gets a paginated list of products.")
            //.WithDescription("Returns products in a paginated format with sorting and total count.")
            ;
        
        group.MapDelete("", async (UpsertEndpointRequest endpointRequest, AppDbContext db) =>
            {
                var product = await db
                    .Products
                    .Include(x => x.Dimensions)
                    .SingleAsync(x => x.Id == endpointRequest.ProductId);
                
                var existingDimensionCount = product.Dimensions.Count(x => x.Id == endpointRequest.DimensionId);

                if (existingDimensionCount == 0)
                {
                    return Results.Conflict("Dimension is not attached to the product");
                }
                
                var dimensionsToDetach = await db.Dimensions.SingleAsync(x => x.Id == endpointRequest.DimensionId);
                
                product.Dimensions.Remove(dimensionsToDetach);
                
                await db.SaveChangesAsync();
                
                return Results.NoContent();
            })
            .WithName("ProductDimensionAttachDimensions")
            //.Produces<PaginationResponse<Entities.Product>>(StatusCodes.Status200OK)
            //.WithSummary("Gets a paginated list of products.")
            //.WithDescription("Returns products in a paginated format with sorting and total count.")
            ;
        
        return group;
    }
}