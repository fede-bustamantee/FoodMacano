using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FoodMacanoServices.Models
{
    public class Encargue
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El ProductoId es requerido.")]
        public int ProductoId { get; set; }

        [JsonIgnore] // Ignorar Producto en la serialización/deserialización
        public Producto Producto { get; set; }

        [Required(ErrorMessage = "La cantidad es requerida.")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0.")]
        public int Cantidad { get; set; }

        public DateTime FechaEncargue { get; set; }

        [Required(ErrorMessage = "El UsuarioId es requerido.")]
        public int UsuarioId { get; set; }

        [JsonIgnore] // Ignorar Usuario en la serialización/deserialización
        public Usuario Usuario { get; set; }
    }
}
