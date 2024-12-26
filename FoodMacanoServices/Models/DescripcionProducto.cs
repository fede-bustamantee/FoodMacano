namespace FoodMacanoServices.Models
{
    public class DescripcionProducto
    {
        public int Id { get; set; }
        public string DescripcionCorta { get; set; } = string.Empty;
        public string DescripcionLarga { get; set; } = string.Empty;
        public Producto? Producto { get; set; }
    }
}
