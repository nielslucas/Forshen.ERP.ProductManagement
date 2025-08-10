using Forshen.ERP.ProductManagement.Infrastructure;
using System.Linq.Dynamic.Core;
using Forshen.ERP.ProductManagement.Api.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Forshen.ERP.ProductManagement.Api.Endpoints.Product.Overview;

[RouteGroupEndpoint(RouteGroupEndpointAttribute.Group.Products)]
public class ProductOverviewEndpoint : IRouteGroupEndpoint
{
    public RouteGroupBuilder MapGroup(RouteGroupBuilder group)
    {
        group.MapGet("overview", async (AppDbContext db, 
            [FromQuery] int page = 1, 
            [FromQuery] int rowsPerPage = 10, 
            [FromQuery] string sortBy = "id", 
            [FromQuery] bool descending = true) =>
            {
                // Validate page and rowsPerPage
                if (page < 1) page = 1;
                if (rowsPerPage < 1) rowsPerPage = 10;

                // Apply pagination
                var baseQuery = db
                    .Products;

                // Page query
                var pageQuery = baseQuery.Skip((page - 1) * rowsPerPage)
                    .Take(rowsPerPage);
                
                pageQuery = descending
                    ? pageQuery.OrderBy($"{sortBy} descending")
                    : pageQuery.OrderBy(sortBy);
                
                // Total items query
                var totalItemsQuery = baseQuery;

                var response = new PaginationResponse<Entities.Product>
                {
                    PageItems = await pageQuery.ToListAsync(),
                    TotalItemsCount = await totalItemsQuery.CountAsync()
                };

                return response;
            })
            .WithName("ProductOverview")
            .Produces<PaginationResponse<Entities.Product>>(StatusCodes.Status200OK)
            .WithSummary("Gets a paginated list of products.")
            .WithDescription("Returns products in a paginated format with sorting and total count.");
        
        return group;
    }
}