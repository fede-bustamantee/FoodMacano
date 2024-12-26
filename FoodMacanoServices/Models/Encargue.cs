namespace FoodMacanoServices.Models
{
    public class Encargue
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaEncargue { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }


}
