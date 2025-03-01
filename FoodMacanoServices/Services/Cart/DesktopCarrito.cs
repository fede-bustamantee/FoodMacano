using FoodMacanoServices.Models.Cart;
using FoodMacanoServices.Models.Common;

namespace FoodMacanoServices.Services.Cart
{
    public class DesktopCarrito
    {
        // Instancia única de la clase
        private static DesktopCarrito instance;

        // Objeto de bloqueo para garantizar seguridad en entornos multihilo
        private static readonly object lockObject = new object();

        // Lista de productos en el carrito
        public List<CarritoCompra> Items { get; private set; }

        // Total del precio de los productos en el carrito
        public decimal Total { get; private set; }

        // Evento que se dispara cuando hay cambios en el carrito
        public event EventHandler CarritoActualizado;

        // Constructor privado para evitar instancias múltiples (Singleton)
        private DesktopCarrito()
        {
            Items = new List<CarritoCompra>(); // Inicializa la lista de productos
            Total = 0; // Inicializa el total en cero
        }

        // Propiedad para obtener la instancia única del carrito (Singleton)
        public static DesktopCarrito Instance
        {
            get
            {
                // Verifica si la instancia es nula y la crea si es necesario
                if (instance == null)
                {
                    lock (lockObject) // Bloqueo para seguridad en hilos
                    {
                        instance ??= new DesktopCarrito();
                    }
                }
                return instance;
            }
        }

        // Método para agregar un producto al carrito
        public void AgregarProducto(Producto producto)
        {
            // Busca si el producto ya existe en el carrito
            var itemExistente = Items.FirstOrDefault(i => i.Producto.Id == producto.Id);

            if (itemExistente != null)
            {
                // Si el producto ya está en el carrito, aumenta la cantidad
                itemExistente.Cantidad++;
            }
            else
            {
                // Si el producto no está en el carrito, lo agrega con cantidad 1
                Items.Add(new CarritoCompra
                {
                    Producto = producto,
                    Cantidad = 1
                });
            }

            // Actualiza el total del carrito
            ActualizarTotal();

            // Dispara el evento para notificar cambios
            CarritoActualizado?.Invoke(this, EventArgs.Empty);
        }

        // Método para remover un producto del carrito
        public void RemoverProducto(CarritoCompra item)
        {
            // Elimina el producto de la lista
            Items.Remove(item);

            // Actualiza el total después de remover
            ActualizarTotal();

            // Dispara el evento para notificar cambios
            CarritoActualizado?.Invoke(this, EventArgs.Empty);
        }

        // Método para limpiar todo el carrito
        public void LimpiarCarrito()
        {
            // Vacía la lista de productos
            Items.Clear();

            // Reinicia el total a 0
            Total = 0;

            // Dispara el evento para notificar cambios
            CarritoActualizado?.Invoke(this, EventArgs.Empty);
        }

        // Método privado para actualizar el total del carrito
        private void ActualizarTotal()
        {
            // Calcula el total sumando el precio de cada producto por su cantidad
            Total = Items.Sum(item => item.Producto.Precio * item.Cantidad);
        }
    }
}
