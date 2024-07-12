
using Foody.Core.Application.HATEOAS;

namespace Foody.Core.Application.Interfaces.HATEOAS
{
    public interface ILinkFactory
    {
        public void CreateLink(string endpointName, string rel, HttpMethod method, object? routeValues = null);
        List<Link> GetLinks();
    }
}
