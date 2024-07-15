

using Foody.Core.Domain.Enums;

namespace Foody.Core.Application.Constants
{
    public class DishesConstants
    {
        public const string CreateDishSuccess = "Plato creado satisfactoriamente";
        public const string CreateDishError = "Error al crear el plato";
        public const string CreateDishInvalid = "Datos inválidos. Asegurate de que todos los campos estan llenos y que el plato tiene al menos un ingrediente existente.";
        public static readonly string CategoryDishInvalid = $"La categoría del plato es inválida. Asegurate de que la categoría es una de las siguientes: Entrada ({(int)DishCategory.Starter}), Principal ({(int)DishCategory.MainCourse}), Postre ({(int)DishCategory.Dessert}) o Bebida ({(int)DishCategory.Drink}).";
    }
}
