

using Foody.Core.Application.Constants;
using Foody.Core.Application.Interfaces.MediatR.CQRS.Commands;
using Foody.Core.Domain.Entities;
using Foody.Core.Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Foody.Core.Application.Features.Orders.Delete
{
    public class DeleteOrderCommandHandler(IRepository<Order> orderRepository, IRepository<DishOrder> dishOrderRepository) 
        : ICommandHandler<DeleteOrderCommand, DeleteOrderCommandResult>
    {
        public async Task<DeleteOrderCommandResult> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            Order? order = await orderRepository.GetByIdAsync(request.Id, cancellationToken);

            if(order is null) return new DeleteOrderCommandResult(StatusCodes.Status404NotFound, OrdersConstants.OrderNotFound);

            List<DishOrder> dishOrders = await dishOrderRepository.GetAsync(cancellationToken, di => di.OrderId == request.Id);
            await dishOrderRepository.BulkDeleteAsync(dishOrders, cancellationToken);

            await orderRepository.DeleteAsync(request.Id, cancellationToken, false);


            return new DeleteOrderCommandResult(StatusCodes.Status204NoContent, OrdersConstants.DeleteOrderSucceed);
        }
    }
}
