using System.ComponentModel.DataAnnotations;

namespace Foody.API.Requests.Orders
{
    public class UpdateOrderRequest : IValidatableObject
    {
            [Required(ErrorMessage = "El id de la orden que quieres editar es requerido")]
            public Guid OrderId { get; set; }

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
