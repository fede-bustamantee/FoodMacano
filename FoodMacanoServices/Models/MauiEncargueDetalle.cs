using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMacanoServices.Models
{
    public class MauiEncargueDetalle
    {
        public int Id { get; set; }
        public int EncargueId { get; set; }
        public MauiEncargue Encargue { get; set; }
        public int ProductoId { get; set; }
        public string NombreProducto { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public Producto Producto { get; set; }
    }
}
