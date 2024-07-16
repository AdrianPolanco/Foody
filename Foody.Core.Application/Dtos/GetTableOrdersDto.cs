

using Foody.Core.Domain.Enums;

namespace Foody.Core.Application.Dtos
{
    public record GetTableOrdersDto(TableDto Table, List<PlainOrderDto> Orders);

    public record PlainOrderDto(Guid Id, List<DishDto> Dishes, decimal Subtotal, OrderState State, DateTime CreatedAt);
}
