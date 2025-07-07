using System.Reflection;

namespace Forshen.ERP.ProductManagement.Api.Endpoints;

public static class EndpointRegister
{
    public static void RegisterEndpoints(this IEndpointRouteBuilder endpoints)
    {
        // Find all endpoint types implementing IRouteGroupEndpoint
        var endpointTypes = AppDomain.CurrentDomain
            .GetAssemblies()
            .SelectMany(asm => asm.GetTypes())
            .Where(t => typeof(IRouteGroupEndpoint).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);
        
        // Group endpoints by Group attribute
        var groupedEndpoints = endpointTypes
            .Select(t => new
            {
                Type = t,
                Attribute = t.GetCustomAttribute<RouteGroupEndpointAttribute>()
            })
            .Where(x => x.Attribute != null)
            .GroupBy(x => x.Attribute!.GroupName);
        
        // 
        foreach (var group in groupedEndpoints)
        {
            // Create RouteGroupBuilder for this group, e.g. "/products" for Products
            var groupName = group.Key.ToString();

            var routeGroupBuilder = endpoints.MapGroup(groupName).WithTags(groupName);

            // Now instantiate and invoke each endpoint in this group
            foreach (var ep in group)
            {
                if (Activator.CreateInstance(ep.Type) is IRouteGroupEndpoint instance)
                {
                    instance.MapGroup(routeGroupBuilder);
                }
            }
        }
    }
}