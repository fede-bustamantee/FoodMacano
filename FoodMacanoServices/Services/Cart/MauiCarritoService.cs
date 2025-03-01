using FoodMacanoServices.Models.Cart;
using FoodMacanoServices.Models.Common;
using FoodMacanoServices.Models.Orders;
using FoodMacanoServices.Services.FireAuth;
using FoodMacanoServices.Services.Orders;

namespace FoodMacanoServices.Services.Carrito
{
    public class MauiCarritoService
    {
        private readonly List<CarritoCompra> _carrito;
        private readonly MauiEncargueService _encargueService;
        private readonly MauiFirebaseAuthService _authService;

        public MauiCarritoService(MauiEncargueService encargueService, MauiFirebaseAuthService authService)
        {
            _carrito = new List<CarritoCompra>(); // Inicializa el carrito vacío
            _encargueService = encargueService ?? throw new ArgumentNullException(nameof(encargueService)); // Verifica que el servicio de encargue no sea nulo
            _authService = authService ?? throw new ArgumentNullException(nameof(authService)); // Verifica que el servicio de autenticación no sea nulo
        }

        public async Task AddToCartAsync(Producto producto)
        {
            // Verifica si el producto ya está en el carrito
            var existente = _carrito.FirstOrDefault(c => c.ProductoId == producto.Id);
            if (existente != null)
            {
                // Si ya está, solo se incrementa la cantidad
                existente.Cantidad += 1;
            }
            else
            {
                // Si no está, se agrega un nuevo producto con cantidad 1
                _carrito.Add(new CarritoCompra
                {
                    ProductoId = producto.Id,
                    Cantidad = 1,
                    Producto = producto
                });
            }
            await Task.CompletedTask; // Simula una tarea asincrónica, no se realiza ninguna operación asíncrona real aquí
        }

        // Método para obtener el número de elementos únicos en el carrito
        public async Task<int> GetUniqueItemCountAsync()
        {
            return await Task.FromResult(_carrito.Count); // Devuelve el número de productos únicos en el carrito
        }

        // Método para obtener los artículos del carrito
        public async Task<List<CarritoCompra>> GetCartItemsAsync()
        {
            return await Task.FromResult(_carrito); // Devuelve la lista de artículos en el carrito
        }
        public async Task ClearCartAsync(int? productId = null)
        {
            if (productId.HasValue)
            {
                // Si se pasa un ID de producto, se elimina solo ese producto
                var productToRemove = _carrito.FirstOrDefault(p => p.Id == productId.Value);
                if (productToRemove != null)
                {
                    _carrito.Remove(productToRemove);
                }
            }
            else
            {
                // Si no se pasa un ID de producto, se limpia todo el carrito
                _carrito.Clear();
            }
            await Task.CompletedTask; // Simula una tarea asincrónica
        }
        public async Task RemoveFromCartAsync(int productoId)
        {
            // Buscar y eliminar el producto del carrito
            var item = _carrito.FirstOrDefault(c => c.ProductoId == productoId);
            if (item != null)
            {
                _carrito.Remove(item);
            }
            await Task.CompletedTask; // Simula una tarea asincrónica
        }
        public async Task UpdateCartItemAsync(CarritoCompra item)
        {
            // Buscar el artículo en el carrito y actualizar su cantidad
            var existente = _carrito.FirstOrDefault(c => c.ProductoId == item.ProductoId);
            if (existente != null)
            {
                existente.Cantidad = item.Cantidad;
            }
            await Task.CompletedTask; // Simula una tarea asincrónica
        }
        public async Task CheckoutAsync(string direccion)
        {
            if (!_carrito.Any())
            {
                throw new InvalidOperationException("El carrito está vacío."); // Si el carrito está vacío, lanza una excepción
            }

            try
            {
                // Obtener el ID y nombre del usuario autenticado
                var userId = _authService.GetCurrentUserId();
                var displayName = (await _authService.GetCurrentUser())?.DisplayName;

                if (string.IsNullOrEmpty(userId))
                {
                    throw new InvalidOperationException("Usuario no autenticado."); // Si el usuario no está autenticado, lanza una excepción
                }

                // Crear los detalles del pedido a partir de los artículos del carrito
                var detalles = _carrito.Select(item => new MauiEncargueDetalle
                {
                    ProductoId = item.ProductoId,
                    NombreProducto = item.Producto?.Nombre ?? "Producto Desconocido", // Si el nombre del producto es nulo, se usa "Producto Desconocido"
                    PrecioUnitario = item.Producto?.Precio ?? 0,
                    Cantidad = item.Cantidad,
                }).ToList();

                // Crear un nuevo objeto de pedido (encargue) con la información obtenida
                var nuevoEncargue = new MauiEncargue
                {
                    FechaEncargue = DateTime.UtcNow, // Fecha y hora actual del pedido
                    UserId = userId,
                    UserDisplayName = displayName ?? "Usuario desconocido", // Si el nombre de usuario es nulo, se usa "Usuario desconocido"
                    Direccion = direccion, // Dirección ingresada por el usuario
                    Detalles = detalles,
                    Total = detalles.Sum(d => d.Subtotal) // Total calculado sumando los subtotales de los artículos
                };

                // Añadir el nuevo pedido al sistema
                await _encargueService.AddEncargueAsync(nuevoEncargue);

                // Limpiar el carrito después de procesar el pedido
                await ClearCartAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al procesar el pedido: {ex.Message}", ex);
            }
        }
    }
}