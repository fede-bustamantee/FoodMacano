using FoodMacanoServices.Interfaces;

namespace FoodMacanoServices.Models.Common
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string ImagenUrl { get; set; } = string.Empty;
        public int Precio { get; set; }
        public string Calidad { get; set; } = string.Empty;
        public int Calorias { get; set; }

        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }

        public int DescripcionProductoId { get; set; }
        public DescripcionProducto? DescripcionProducto { get; set; }
    }
}
