using Foody.Core.Application.HATEOAS;
using Foody.Core.Application.Interfaces.HATEOAS;

namespace Foody.API.Services.Factories
{
    public class LinkFactory: ILinkFactory
    {
        private readonly List<Link> _links = new List<Link>();

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly LinkGenerator _linkGenerator;

        public LinkFactory(LinkGenerator linkGenerator, IHttpContextAccessor httpContextAccessor)
        {
            _linkGenerator = linkGenerator;
            _httpContextAccessor = httpContextAccessor;
        }

        public void CreateLink(string endpointName, string rel, HttpMethod method, object? routeValues = null)
        {
            Link link = new Link(
                Href: _linkGenerator.GetUriByName(_httpContextAccessor.HttpContext!, endpointName, routeValues ?? new { })!,
                Rel: rel,
                Method: method.Method);
            _links.Add(link);
        }

        public List<Link> GetLinks() => _links;
    }
}
