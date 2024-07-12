using Foody.Core.Application.HATEOAS;

namespace Foody.Core.Application.Interfaces.HATEOAS
{
    public class HateoasRoute
    {
            public string ControllerName { get; set; } = null!;
            public List<BaseLinkData> Links { get; set; } = new List<BaseLinkData>();
    }
}
