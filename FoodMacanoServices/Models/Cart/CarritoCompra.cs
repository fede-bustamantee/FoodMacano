using FoodMacanoServices.Models.Common;

namespace FoodMacanoServices.Models.Cart
{
    public class CarritoCompra
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public int ProductoId { get; set; }
        public Producto? Producto { get; set; }
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
