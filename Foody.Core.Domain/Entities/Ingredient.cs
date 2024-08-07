﻿

using Foody.Core.Domain.Entities.Base;

namespace Foody.Core.Domain.Entities
{
    public class Ingredient : Entity
    {
        public string Name { get; set; } = null!;
        public List<DishIngredient> DishesIngredients { get; set; } = null!;
        public List<Dish> Dishes { get; set; } = new List<Dish>();  
    }
}
