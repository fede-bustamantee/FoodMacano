using FoodMacanoServices.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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
        [JsonIgnore] // Evita que la contraseña se serialice en las respuestas JSON
        public string Password { get; set; } = string.Empty;

        public TipoUsuarioEnum TipoUsuario { get; set; }

        [Required(ErrorMessage = "El FirebaseId es requerido")]
        public string FirebaseId { get; set; } = string.Empty;
    }
}