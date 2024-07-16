using Foody.Core.Domain.Enums;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Foody.API.Requests.Tables
{
    public class CreateTableRequest : IValidatableObject
    {
        [Required(ErrorMessage = "La descripción es requerida.")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "La cantidad de asientos es requerida.")]
        [Range(1, 13, ErrorMessage = "La cantidad de asientos debe estar entre 0 y 13 personas.")]
        public int Seats { get; set; }

        [Required(ErrorMessage = "El estado de la mesa es requerido.")]
        [SwaggerSchema($"El estado del elemento (1 = Disponible, 2 = En atención, 3 = Atendida)", Nullable = false)]
        public TableState State { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            bool isValidTableState = Enum.IsDefined(typeof(TableState), State);

            if(!isValidTableState) yield return new ValidationResult("El estado de la mesa no es válido.", new[] { nameof(State) });
            
        }
    }
}
