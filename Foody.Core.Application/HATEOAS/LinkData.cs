

namespace Foody.Core.Application.HATEOAS
{
    public record LinkData(string endpoint, HttpMethod method, string rel, object? routeValues = null) : BaseLinkData(endpoint, method, rel);
    public record class BaseLinkData(string endpoint, HttpMethod method, string rel);
}
