

using Foody.Core.Domain.Entities.Base;

namespace Foody.Core.Domain.Entities
{
    public class DishOrder : Entity
    {
        public Guid DishId { get; set; }
        public Dish Dish { get; set; } = null!;
        public Guid OrderId { get; set; }
        public Order Order { get; set; } = null!;
    }
}
