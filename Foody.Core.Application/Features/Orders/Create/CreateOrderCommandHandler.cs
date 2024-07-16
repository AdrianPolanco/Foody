using AutoMapper;
using Foody.Core.Application.Constants;
using Foody.Core.Application.Dtos;
using Foody.Core.Application.Interfaces.MediatR.CQRS.Commands;
using Foody.Core.Domain.Entities;
using Foody.Core.Domain.Enums;
using Foody.Core.Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Foody.Core.Application.Features.Orders.Create
{
    public class CreateOrderCommandHandler(IRepository<DishOrder> dishOrderRepository, IRepository<DinnerTable> tableRepository,
        IRepository<Dish> dishRepository, IRepository<Order> orderRepository, IMapper mapper) 
        : ICommandHandler<CreateOrderCommand, CreateOrderCommandResult>
    {
        public async Task<CreateOrderCommandResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            DinnerTable? table = await tableRepository.GetByIdAsync(request.TableId, cancellationToken);

            //Si la tabla no existe retornar un 404
            if (table is null) return new CreateOrderCommandResult(null, StatusCodes.Status404NotFound, OrdersConstants.TableNotFound);

            List<Guid> repeatedGuids = request.DishesId.GroupBy(d => d).Where(g => g.Count() > 1).Select(g => g.Key).ToList();

            List<Dish> dishes = await dishRepository.GetAsync(cancellationToken, d => request.DishesId.Contains(d.Id));

            bool areThereInvalidGuids = request.DishesId.Except(dishes.Select(d => d.Id)).Any();

            //Si no hay platos o uno de los ids no existe en la tabla retornar un 400 Bad Request
            if (!dishes.Any() || areThereInvalidGuids ) return new CreateOrderCommandResult(null, StatusCodes.Status400BadRequest, OrdersConstants.CreateOrderInvalid);

            Order order = new Order { TableId = table.Id, State = OrderState.InProcess};

            order.Subtotal = dishes.Sum(d =>
            {
                //Si el id del plato se repite, multiplicar el precio por la cantidad de veces que se repite, sino, simplemente retornar el precio para sumarlo
                if (repeatedGuids.Contains(d.Id))
                {
                    int repeatedCount = request.DishesId.Count(id => id == d.Id);
                    return d.Price * repeatedCount;
                }else return d.Price;
            });

            order = await orderRepository.CreateAsync(order, cancellationToken);

            List<DishOrder> dishOrders = request.DishesId.Select(d => new DishOrder { DishId = d, OrderId = order.Id }).ToList();

            await dishOrderRepository.BulkInsertAsync(dishOrders, cancellationToken);

           // List<DishDto> dishesDtos = mapper.Map<List<DishDto>>(dishes);

            order.Dishes = dishes;
            order.Table = table;

            OrderDto orderDto = mapper.Map<OrderDto>(order);

            return new CreateOrderCommandResult(orderDto, StatusCodes.Status201Created, OrdersConstants.CreateOrderSuccess);
        }
    }
}
