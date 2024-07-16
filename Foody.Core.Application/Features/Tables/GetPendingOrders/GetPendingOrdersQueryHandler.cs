

using AutoMapper;
using Foody.Core.Application.Dtos;
using Foody.Core.Application.Interfaces.MediatR.CQRS.Queries;
using Foody.Core.Domain.Entities;
using Foody.Core.Domain.Enums;
using Foody.Core.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;

namespace Foody.Core.Application.Features.Tables.GetPendingOrders
{
    public class GetPendingOrdersQueryHandler(IRepository<Order> orderRepository, IRepository<DinnerTable> tableRepository, IRepository<DishOrder> dishOrderRepository, IMapper mapper)
        : IQueryHandler<GetPendingOrdersQuery, GetPendingOrdersQueryResult>
    {
        public async Task<GetPendingOrdersQueryResult> Handle(GetPendingOrdersQuery request, CancellationToken cancellationToken)
        {
            // Obtener la mesa por su Id
            DinnerTable? table = await tableRepository.GetByIdAsync(request.Id, cancellationToken);
            if (table is null) return new GetPendingOrdersQueryResult(null, 0, StatusCodes.Status404NotFound);

            // Obtener todas las órdenes en proceso para esta mesa
            List<Order> orders = await orderRepository.GetAsync(
                cancellationToken,
                filter: o => o.TableId == request.Id && o.State == OrderState.InProcess && !o.Deleted,
                readOnly: false,
                includes: [o => o.DishesOrders] // Incluir DishesOrders aquí
            );

            // Obtener los IDs de DishOrders asociados a estas órdenes
            var dishOrderIds = orders.SelectMany(o => o.DishesOrders.Select(d => d.Id)).ToList();

            // Obtener los DishOrders asociados a estas órdenes
            List<DishOrder> dishOrders = await dishOrderRepository.GetAsync(
                cancellationToken,
                filter: d => dishOrderIds.Contains(d.Id),
                readOnly: true,
                includes: [o => o.Dish]  // Incluir la propiedad Dish en DishOrder
            );

            // Obtener los platos (Dish) a partir de los DishOrders
            List<Dish> dishes = dishOrders.Select(d => d.Dish).ToList();

            // Asignar los Dishes a las órdenes correspondientes
            orders = orders.Select(o =>
            {
                var orderDishIds = o.DishesOrders.Select(d => d.DishId).ToList();
                o.Dishes = dishes.Where(dish => orderDishIds.Contains(dish.Id)).ToList();
                return o;
            }).ToList();

            // Mapear la entidad de mesa a su DTO correspondiente
            TableDto tableDto = mapper.Map<TableDto>(table);
            List<PlainOrderDto> plainOrderDto = mapper.Map<List<PlainOrderDto>>(orders);
            GetTableOrdersDto tableOrdersDto = new GetTableOrdersDto(tableDto, plainOrderDto);

            // Retornar el resultado deseado
            return new GetPendingOrdersQueryResult(tableOrdersDto, tableOrdersDto.Orders.Count, StatusCodes.Status200OK);
        }
    }
  }

