namespace FoodMacanoServices.Models
{
    public class Encargue
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public string NombreProducto { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaEncargue { get; set; }
    }
}
