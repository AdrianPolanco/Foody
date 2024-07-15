using Foody.Core.Application.Features.Dishes.Create;
using Foody.Core.Application.Features.Dishes.Update;
using Foody.Core.Application.Features.Ingredients.Create;
using Foody.Core.Application.HATEOAS;

namespace Foody.API.Responses
{
    public record LoginResponse(string Token);
    public record SignUpUserResponse(Guid Id, string Name, string LastName, string Username, string Email, string Role, List<Link> Links);
    public record CreateIngredientResponse(CreateIngredientCommandResult result /*,List<Link> Links*/);
    public record CreateDishResponse(CreateDishCommandResult data);
    public record UpdateDishResponse(UpdateDishCommandResult data);
}
