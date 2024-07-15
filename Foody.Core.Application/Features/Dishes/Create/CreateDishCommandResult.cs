using Foody.Core.Domain.Entities;
namespace Foody.Core.Application.Features.Dishes.Create
{
    public record CreateDishCommandResult(Dish? Dish, int StatusCode, string Message);
}