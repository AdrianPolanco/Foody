using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Foody.API.Requests.Users
{
    public record SignUpUserRequest : IValidatableObject
    {
        [Required]
        [MinLength(1, ErrorMessage = "El nombre debe tener al menos 1 caracter")]
        [MaxLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑüÜ\s'-]*$", ErrorMessage = "El apellido solo puede contener letras y caracteres latinos")]
        [SwaggerSchema(Description = "Nombre del usuario")]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(3, ErrorMessage = "El apellido debe tener al menos 3 caracteres")]
        [MaxLength(100, ErrorMessage = "El apellido no puede tener más de 100 caracteres")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑüÜ\s'-]*$",
        ErrorMessage = "El apellido solo puede contener letras y caracteres latinos")]
        [SwaggerSchema(Description = "Apellido del usuario")]
        public string Lastname { get; set; } = null!;

        [Required]
        [MinLength(6, ErrorMessage = "El nombre de usuario debe tener al menos 6 caracteres")]
        [MaxLength(35, ErrorMessage = "El nombre de usuario no puede tener más de 35 caracteres")]
        [SwaggerSchema(Description = "Nombre de usuario")]
        public string Username { get; set; } = null!;

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "El email no es válido")]
        [MaxLength(100, ErrorMessage = "El email no puede tener más de 100 caracteres")]
        [SwaggerSchema(Description = "Correo electrónico del usuario")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "La contraseña es requerida")]
        [MinLength(8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d.*\d)(?=.*[\W_])[a-zA-Z\d\W_]{8,}$",
        ErrorMessage = "La contraseña debe tener al menos una minúscula, una mayúscula, dos números y un caracter especial")]
        [SwaggerSchema(Description = "Contraseña del usuario")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "La confirmación de la contraseña es requerida")]
        [SwaggerSchema(Description = "Confirmación de la contraseña")]
        public string ConfirmPassword { get; set; } = null!;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Password != ConfirmPassword) yield return new ValidationResult("Las contraseñas no coinciden", new[] { nameof(Password), nameof(ConfirmPassword) });
        }
    }

}






