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

        public MauiCarritoService(MauiEncargueService encargueService, MauiFirebaseAuthService authService)
        {
            _carrito = new List<CarritoCompra>();
            _encargueService = encargueService ?? throw new ArgumentNullException(nameof(encargueService));
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
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
                throw new InvalidOperationException("El carrito está vacío.");
            }

            try
            {
                var userId = _authService.GetCurrentUserId();
                if (string.IsNullOrEmpty(userId))
                {
                    throw new InvalidOperationException("Usuario no autenticado.");
                }

                var detalles = _carrito.Select(item => new MauiEncargueDetalle
                {
                    ProductoId = item.ProductoId,
                    NombreProducto = item.Producto?.Nombre ?? "Producto Desconocido",
                    PrecioUnitario = item.Producto?.Precio ?? 0,
                    Cantidad = item.Cantidad
                }).ToList();

                var nuevoEncargue = new MauiEncargue
                {
                    FechaEncargue = DateTime.UtcNow,
                    Estado = "Pendiente",
                    UserId = userId,
                    Detalles = detalles,
                    Total = detalles.Sum(d => d.Subtotal)
                };

                await _encargueService.AddEncargueAsync(nuevoEncargue);
                await ClearCartAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al procesar el pedido: {ex.Message}", ex);
            }
        }
    }
}