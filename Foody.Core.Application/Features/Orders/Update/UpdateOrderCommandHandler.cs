

using AutoMapper;
using Foody.Core.Application.Constants;
using Foody.Core.Application.Dtos;
using Foody.Core.Application.Features.Orders.Create;
using Foody.Core.Application.Interfaces.MediatR.CQRS.Commands;
using Foody.Core.Domain.Entities;
using Foody.Core.Domain.Enums;
using Foody.Core.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;

namespace Foody.Core.Application.Features.Orders.Update
{
    public class UpdateOrderCommandHandler(IMapper mapper, IRepository<DishOrder> dishOrderRepository, IRepository<Dish> dishRepository, IRepository<Order> orderRepository) 
        : ICommandHandler<UpdateOrderCommand, UpdateOrderCommandResult>
    {
        public async Task<UpdateOrderCommandResult> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            Expression<Func<Order, object>>[] includes = new Expression<Func<Order, object>>[] { o => o.Table };

            Order? order = await orderRepository.GetByIdAsync(request.OrderId, cancellationToken, includes: includes);

            //Si la orden no existe retornar un 404
            if (order is null) return new UpdateOrderCommandResult(null, StatusCodes.Status404NotFound, OrdersConstants.OrderNotFound);

            List<DishOrder> oldDishes = await dishOrderRepository.GetAsync(cancellationToken, di => di.OrderId == request.OrderId);

            List<Guid> repeatedGuids = request.DishesId.GroupBy(d => d).Where(g => g.Count() > 1).Select(g => g.Key).ToList();

            List<Dish> dishes = await dishRepository.GetAsync(cancellationToken, d => request.DishesId.Contains(d.Id));

            bool areThereInvalidGuids = request.DishesId.Except(dishes.Select(d => d.Id)).Any();

            //Si no hay platos o uno de los ids no existe en la tabla retornar un 400 Bad Request
            if (!dishes.Any() || areThereInvalidGuids) return new UpdateOrderCommandResult(null, StatusCodes.Status400BadRequest, OrdersConstants.CreateOrderInvalid);

            order.Subtotal = dishes.Sum(d =>
            {
                //Si el id del plato se repite, multiplicar el precio por la cantidad de veces que se repite, sino, simplemente retornar el precio para sumarlo
                if (repeatedGuids.Contains(d.Id))
                {
                    int repeatedCount = request.DishesId.Count(id => id == d.Id);
                    return d.Price * repeatedCount;
                }
                else return d.Price;
            });

            order = await orderRepository.UpdateAsync(order, cancellationToken);

            List<DishOrder> dishOrders = request.DishesId.Select(d => new DishOrder { DishId = d, OrderId = order.Id }).ToList();

            await dishOrderRepository.BulkDeleteAsync(oldDishes, cancellationToken);
            await dishOrderRepository.BulkInsertAsync(dishOrders, cancellationToken);

            // List<DishDto> dishesDtos = mapper.Map<List<DishDto>>(dishes);

            order.Dishes = dishes;

            OrderDto orderDto = mapper.Map<OrderDto>(order);

            return new UpdateOrderCommandResult(orderDto, StatusCodes.Status201Created, OrdersConstants.CreateOrderSuccess);
        }
    }
}
