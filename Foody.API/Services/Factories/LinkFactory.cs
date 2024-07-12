using Foody.Core.Application.HATEOAS;
using Foody.Core.Application.Interfaces.HATEOAS;
using Microsoft.AspNetCore.Routing;

namespace Foody.API.Services.Factories
{
    public class LinkFactory : ILinkFactory
    {
        private readonly List<Link> _links = new List<Link>();

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly LinkGenerator _linkGenerator;
        private readonly Hateoas _hateoas;

        public LinkFactory(LinkGenerator linkGenerator, IHttpContextAccessor httpContextAccessor, Hateoas hateoas)
        {
            _linkGenerator = linkGenerator;
            _httpContextAccessor = httpContextAccessor;
            _hateoas = hateoas;
        }

        public void CreateLink(string endpointName, string rel, HttpMethod method, object? routeValues = null)
        {
            HttpContext httpContext = _httpContextAccessor.HttpContext!;
            var routeValuesDict = new RouteValueDictionary(routeValues);

            // Genera la URL usando GetPathByAction para rutas con parámetros de ruta
            string href = _linkGenerator.GetUriByAction(httpContext, action: endpointName, controller: _hateoas.ControllerName, values: routeValuesDict)!;

            Link link = new Link(href, rel, method.Method);
            _links.Add(link);
        }

        public List<Link> GetLinks() => _links;
    }

}
