

using Foody.Core.Application.Interfaces.MediatR.CQRS.Commands;

namespace Foody.Core.Application.Features.Orders.Delete
{
    public record DeleteOrderCommand(Guid Id) : ICommand<DeleteOrderCommandResult>;

    public record DeleteOrderCommandResult(int StatusCode, string Message);
}
