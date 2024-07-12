using Foody.Core.Application.Interfaces.HATEOAS;
using Foody.Shared.Hateoas;
using System.Linq.Expressions;


namespace Foody.Core.Application.HATEOAS
{
    public class Hateoas
    {
        public static string DataKey { get; } = "data";
        public Dictionary<string, List<LinkData>> Data { get; set; } = new Dictionary<string, List<LinkData>>()
        {
            { DataKey, new List<LinkData>() }
        };

        public List<Link> Links { get; set; } = new List<Link>();
        public string ActionName { get; set; } = null!;
        public string ControllerName { get; set; } = null!; 
        public List<HateoasRoute> Routes { get; set; } = new List<HateoasRoute>();
        Expression<Func<HateoasRoute, bool>> Filter { get; set; } = null!;

        public List<HateoasRoute> GetRoutes()
        {
            var routes = Routes.AsQueryable().Where(Filter).ToList();
            return routes;
        }
    }
}
