
using Foody.Core.Domain.Entities.Base;
using Foody.Core.Domain.Enums;

namespace Foody.Core.Domain.Entities
{
    public class Dish : Entity
    {
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int PeopleQuantity { get; set; }
        public List<Ingredient> Ingredients { get; set; } = null!;
        public DishCategory Category { get; set; }
    }
}
