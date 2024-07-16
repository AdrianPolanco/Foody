using System.ComponentModel.DataAnnotations;

namespace Foody.API.Requests.Tables
{
    public class CommandTableRequest
    {
            [Required(ErrorMessage = "La descripción es requerida.")]
            public string Description { get; set; } = null!;

            [Required(ErrorMessage = "La cantidad de asientos es requerida.")]
            [Range(1, 13, ErrorMessage = "La cantidad de asientos debe estar entre 0 y 13 personas.")]
            public int Seats { get; set; }

    }
}
