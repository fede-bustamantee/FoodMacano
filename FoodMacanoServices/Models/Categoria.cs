namespace FoodMacanoServices.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string IconUrl { get; set; } = string.Empty;
        public List<Producto>? Productos { get; set; }
    }
}
