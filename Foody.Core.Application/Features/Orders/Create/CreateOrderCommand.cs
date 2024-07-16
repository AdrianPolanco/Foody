
using Foody.Core.Application.Dtos;
using Foody.Core.Application.Interfaces.MediatR.CQRS.Commands;
using Foody.Core.Domain.Entities;
using Foody.Core.Domain.Enums;

namespace Foody.Core.Application.Features.Orders.Create
{
    public record CreateOrderCommand(Guid TableId, List<Guid> DishesId, OrderState State = OrderState.InProcess): ICommand<CreateOrderCommandResult>;
    public record CreateOrderCommandResult(OrderDto? Order, int StatusCode, string Message);
}
