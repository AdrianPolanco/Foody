
using Foody.Core.Application.Features.Dishes.Create;
using Foody.Core.Application.Interfaces.MediatR.CQRS.Commands;
using Foody.Core.Domain.Enums;

namespace Foody.Core.Application.Features.Dishes.Update
{
    public record UpdateDishCommand(string Name, decimal Price, int PeopleQuantity, List<Guid> Ingredients, DishCategory Category)
        : ICommand<UpdateDishCommandResult>
    {
        public Guid Id { get; set;  }
    }
}
