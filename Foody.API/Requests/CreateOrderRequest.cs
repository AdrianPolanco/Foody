using System.ComponentModel.DataAnnotations;

namespace Foody.API.Requests
{
    public class CreateOrderRequest : IValidatableObject
    {
        [Required(ErrorMessage = "El id de la mesa desde donde se hace la orden es requerido")]
        public Guid TableId { get; set; }

        [Required(ErrorMessage = "La lista de platos es requerida")]
        public List<Guid> DishesId { get; set; } = null!;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DishesId.Count < 1)
            {
                yield return new ValidationResult("La lista de platos no puede estar vacía. Agregue al menos el id de uno de nuestros platos.", new[] { nameof(DishesId) });
            }
        }
    }
}
