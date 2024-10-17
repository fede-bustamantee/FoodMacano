namespace FoodMacanoServices.Models
{
    public class CarritoCompra
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public int ProductoId { get; set; }
        public Producto? Producto { get; set; }
    }
}
