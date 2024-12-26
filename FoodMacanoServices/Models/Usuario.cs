using FoodMacanoServices.Enums;
using System.ComponentModel.DataAnnotations;

namespace FoodMacanoServices.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        public string User { get; set; } = string.Empty;

        [Required(ErrorMessage = "El email es requerido")]
        [EmailAddress(ErrorMessage = "El email no es válido")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña es requerida")]
        [MinLength(6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres")]
        public string Password { get; set; } = string.Empty;

        public TipoUsuarioEnum TipoUsuario { get; set; }
        public string FirebaseId { get; set; }
    }
}
