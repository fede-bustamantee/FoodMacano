using FoodMacanoServices.Models.Common;
using System.Text.Json.Serialization;

namespace FoodMacanoServices.Models.Orders
{
    public class MauiEncargueDetalle
    {
        public int Id { get; set; }
        public int EncargueId { get; set; }
        public virtual MauiEncargue? Encargue { get; set; }

        public int ProductoId { get; set; }
        public string NombreProducto { get; set; } = string.Empty;
        public decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal => Cantidad * PrecioUnitario;

        public virtual Producto? Producto { get; set; }
    }
}