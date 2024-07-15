
using Foody.Core.Application.Features.Dishes.Create;
using Foody.Core.Domain.Entities;

namespace Foody.Core.Application.Features.Dishes.Update
{
    public record UpdateDishCommandResult(Dish? Dish, int StatusCode, string Message);
}
