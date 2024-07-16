

using Foody.Core.Domain.Enums;

namespace Foody.Core.Application.Dtos
{
    public record DishDto(Guid Id, string Name, decimal Price,int PeopleQuantity, DishCategory Category);
}
