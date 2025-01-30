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
        public Producto? Producto { get; set; }  // Vinculado a Producto

        public int Cantidad { get; set; }
        public decimal Subtotal => Producto != null ? Cantidad * Producto.Precio : 0; // Calculado a partir del Producto
    }
}
