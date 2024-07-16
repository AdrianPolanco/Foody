using Foody.Core.Domain.Enums;

namespace Foody.Core.Application.Dtos
{
    public record TableDto(Guid Id, string Name, int Capacity, TableState State);
}
