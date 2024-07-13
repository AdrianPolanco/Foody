using System.ComponentModel.DataAnnotations;

namespace Foody.API.Requests.Ingredient
{
    public class CreateIngredientRequest
    {
        [Required]
        [MinLength(3, ErrorMessage = "No se permiten ingredientes con menos de 3 letras en su nombre")]
        [MaxLength(50, ErrorMessage = "No se permiten ingredientes con más de 50 letras en su nombre")]
        public string Name { get; set; } = null!;
    }
}
