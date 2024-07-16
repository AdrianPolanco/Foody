
using AutoMapper;
using Foody.Core.Application.Constants;
using Foody.Core.Application.Dtos;
using Foody.Core.Application.Interfaces.MediatR.CQRS.Queries;
using Foody.Core.Domain.Entities;
using Foody.Core.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;

namespace Foody.Core.Application.Features.Orders.GetById
{
    public class GetOrderByIdQueryHandler(IEntityService<DishOrder> dishOrderService, IEntityService<DinnerTable> tableService, IMapper mapper) : IQueryHandler<GetOrderByIdQuery, GetOrderByIdQueryResult>
    {
        public async Task<GetOrderByIdQueryResult> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<DishOrder, object>>[]? includes = request.IncludeFurtherData ? [ di => di.Dish, di => di.Order ] : [di => di.Order];

            var dishOrders = await dishOrderService.GetAsync(cancellationToken, includes: includes, filter: di => di.OrderId == request.Id);

            if (!dishOrders.Any() || dishOrders is null) return new GetOrderByIdQueryResult(null, StatusCodes.Status404NotFound, OrdersConstants.OrderNotFound);

            if(!request.IncludeFurtherData)
            {
                Order firstOrder = dishOrders.First().Order;
                OrderDto orderDto = mapper.Map<OrderDto>(firstOrder);

                return new GetOrderByIdQueryResult(orderDto, StatusCodes.Status200OK, OrdersConstants.OrderQuerySuccess);
            }

            List<Dish> dishes = dishOrders.Select(di => di.Dish).ToList();
            DishOrder firstDishOrder = dishOrders.First();

            Order order = firstDishOrder.Order;

            order.Dishes = dishes;

            DinnerTable? table = await tableService.GetByIdAsync(order.TableId, cancellationToken);

            order.Table = table!;

            OrderDto orderDtoWithFurtherData = mapper.Map<OrderDto>(order);

            return new GetOrderByIdQueryResult(orderDtoWithFurtherData, StatusCodes.Status200OK, OrdersConstants.OrderQuerySuccess);

        }
    }
}
