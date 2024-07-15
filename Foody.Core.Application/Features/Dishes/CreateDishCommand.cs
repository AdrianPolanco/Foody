using Foody.Core.Application.Interfaces.MediatR.CQRS.Commands;
using Foody.Core.Domain.Enums;

namespace Foody.Core.Application.Features.Dishes
{
    public record CreateDishCommand(string Name, decimal Price, int PeopleQuantity, List<Guid> Ingredients, DishCategory Category) : ICommand<CreateDishCommandResult>;
}