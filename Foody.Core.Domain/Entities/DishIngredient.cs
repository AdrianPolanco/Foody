

using Foody.Core.Domain.Entities.Base;

namespace Foody.Core.Domain.Entities
{
    public class DishIngredient : Entity
    {
        public Guid DishId { get; set; }
        public Dish Dish { get; set; } = null!;
        public Guid IngredientId { get; set; }
        public Ingredient Ingredient { get; set; } = null!;
    }
}
