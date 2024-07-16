

using Foody.Core.Application.Dtos;
using Foody.Core.Application.Interfaces.MediatR.CQRS.Commands;

namespace Foody.Core.Application.Features.Orders.Update
{
   public record UpdateOrderCommand(Guid OrderId, List<Guid> DishesId) : ICommand<UpdateOrderCommandResult>;

    public record UpdateOrderCommandResult(OrderDto? Order, int StatusCode, string Message);
}
