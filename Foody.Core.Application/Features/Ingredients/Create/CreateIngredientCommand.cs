

using Foody.Core.Application.Interfaces.MediatR.CQRS;
using Foody.Core.Application.Interfaces.MediatR.CQRS.Commands;
using System.Windows.Input;

namespace Foody.Core.Application.Features.Ingredients.Create
{
    public record CreateIngredientCommandResult(string Name, DateTime CreatedAt): IResponse
    {
        public Guid Id { get; set; }
    }
    public record CreateIngredientCommand(string Name) : ICommand<CreateIngredientCommandResult>;
}
