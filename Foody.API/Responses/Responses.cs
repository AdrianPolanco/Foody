using Foody.Core.Application.HATEOAS;

namespace Foody.API.Responses
{
    public record LoginResponse(string Token);
    public record SignUpUserResponse(Guid Id, string Name, string LastName, string Username, string Email, string Role, List<Link> Links);
}
