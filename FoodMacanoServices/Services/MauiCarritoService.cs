using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodMacanoServices.Interfaces;
using FoodMacanoServices.Models;

namespace FoodMacanoServices.Services
{
    public class MauiCarritoService
    {
        private readonly List<CarritoCompra> _carrito;
        private readonly MauiEncargueService _encargueService;
        private readonly MauiFirebaseAuthService _authService;

        public MauiCarritoService()
        {
            _carrito = new List<CarritoCompra>();
        }

        public async Task AddToCartAsync(Producto producto)
        {
            var existente = _carrito.FirstOrDefault(c => c.ProductoId == producto.Id);
            if (existente != null)
            {
                existente.Cantidad += 1;
            }
            else
            {
                _carrito.Add(new CarritoCompra
                {
                    ProductoId = producto.Id,
                    Cantidad = 1,
                    Producto = producto
                });
            }
            await Task.CompletedTask;
        }

        public async Task<int> GetUniqueItemCountAsync()
        {
            return await Task.FromResult(_carrito.Count);
        }

        public async Task<List<CarritoCompra>> GetCartItemsAsync()
        {
            return await Task.FromResult(_carrito);
        }

        public async Task ClearCartAsync()
        {
            _carrito.Clear();
            await Task.CompletedTask;
        }

        public async Task RemoveFromCartAsync(int productoId)
        {
            var item = _carrito.FirstOrDefault(c => c.ProductoId == productoId);
            if (item != null)
            {
                _carrito.Remove(item);
            }
            await Task.CompletedTask;
        }

        // Nuevos métodos necesarios para el CarritoViewModel

        public async Task UpdateCartItemAsync(CarritoCompra item)
        {
            var existente = _carrito.FirstOrDefault(c => c.ProductoId == item.ProductoId);
            if (existente != null)
            {
                existente.Cantidad = item.Cantidad;
            }
            await Task.CompletedTask;
        }

        public async Task CheckoutAsync()
        {
            if (!_carrito.Any())
            {
                throw new InvalidOperationException("El carrito está vacío. No se puede procesar el pedido.");
            }

            try
            {
                // Obtener el usuario autenticado
                var userId = _authService.GetCurrentUserId();
                if (string.IsNullOrEmpty(userId))
                {
                    throw new InvalidOperationException("No se puede procesar el pedido. Usuario no autenticado.");
                }

                // Crear un nuevo MauiEncargue
                var nuevoEncargue = new MauiEncargue
                {
                    FechaEncargue = DateTime.Now,
                    Estado = "Pendiente",
                    Total = _carrito.Sum(item => item.Producto.Precio * item.Cantidad),
                    UserId = userId
                };

                // Registrar el pedido usando MauiEncargueService
                await _encargueService.AddAsync(nuevoEncargue);

                // Limpiar el carrito después de procesar el pedido
                await ClearCartAsync();

                Console.WriteLine("Pedido procesado exitosamente.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al procesar el pedido: {ex.Message}", ex);
            }
        }
    }
}