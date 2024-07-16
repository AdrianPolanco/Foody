
using Foody.Core.Domain.Entities.Base;
using Foody.Core.Domain.Enums;

namespace Foody.Core.Domain.Entities
{
    public class Order : Entity
    {
        public Guid TableId { get; set; }
        public DinnerTable Table { get; set; } = null!;
        public List<DishOrder> DishesOrders { get; set; } = null!;
        public decimal Subtotal { get; set; }
        public OrderState State { get; set; }
        public List<Dish> Dishes { get; set; } = new List<Dish>();
    }
}
