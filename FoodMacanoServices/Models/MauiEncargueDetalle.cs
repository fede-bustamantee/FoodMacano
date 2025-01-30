using System.Text.Json.Serialization;

namespace FoodMacanoServices.Models
{
    public class MauiEncargueDetalle
    {
        public int Id { get; set; }
        public int EncargueId { get; set; }

        [JsonIgnore] // Evita la serialización circular
        public MauiEncargue? Encargue { get; set; }

        public int ProductoId { get; set; }
        public string NombreProducto { get; set; } = string.Empty;
        public decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }

        public decimal Subtotal => Cantidad * PrecioUnitario; // Se calcula automáticamente

        public Producto? Producto { get; set; }
    }
}
