namespace Forshen.ERP.ProductManagement.Api.Endpoints;

public class RouteGroupEndpointAttribute : Attribute
{
    public Group GroupName { get; }

    public RouteGroupEndpointAttribute(Group groupName)
    {
        GroupName = groupName;
    }

    public enum Group
    {
        Products
        , Movies
    }
}