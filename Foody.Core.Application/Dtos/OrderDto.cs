
using Foody.Core.Domain.Enums;

namespace Foody.Core.Application.Dtos
{
    public record OrderDto(Guid Id, TableDto Table, List<DishDto> Dishes, decimal Subtotal, OrderState State, DateTime CreatedAt);
}
