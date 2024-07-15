using Foody.Core.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Foody.API.Requests.Dishes
{
    public record CreateDishRequest : IValidatableObject
    {
        [Required(ErrorMessage = "El nombre del plato es requerido")]
        [MinLength(3, ErrorMessage = "El nombre del plato debe tener al menos 3 letras")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "El precio del plato es requerido")]
        [Range(0.01, 500000, ErrorMessage = "El precio del plato debe estar entre 0.01 y 500,000")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "La cantidad de personas es requerida")]
        [Range(1, 12, ErrorMessage = "La cantidad de personas debe estar entre 1 y 100")]
        public int PeopleQuantity { get; set; }

        [Required(ErrorMessage = "La categoría del plato es requerida")]
        public List<Guid> Ingredients { get; set; } = null!;

        [Required(ErrorMessage = "La categoría del plato es requerida")]
        public DishCategory Category { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(Ingredients.Count < 1)
            {
                yield return new ValidationResult("El plato debe tener al menos un ingrediente", new[] { nameof(Ingredients) });
            }
        }
    }
}