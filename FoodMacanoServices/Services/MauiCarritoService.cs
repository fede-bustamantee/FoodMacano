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
                throw new InvalidOperationException("El carrito está vacío. No se puede procesar el pedido.");
            }

            try
            {
                var userId = _authService.GetCurrentUserId();
                if (string.IsNullOrEmpty(userId))
                {
                    throw new InvalidOperationException("No se puede procesar el pedido. Usuario no autenticado.");
                }

                // Crear los detalles del encargue a partir del carrito
                var detalles = _carrito.Select(item => new MauiEncargueDetalle
                {
                    ProductoId = item.ProductoId,
                    Producto = item.Producto,  // Ya obtenemos los datos desde Producto
                    Cantidad = item.Cantidad,
                    EncargueId = 0  // Se asignará automáticamente al guardarlo en la base de datos
                }).ToList();

                // Crear el nuevo encargue con sus detalles
                var nuevoEncargue = new MauiEncargue
                {
                    FechaEncargue = DateTime.Now,
                    Estado = "Pendiente",
                    Total = detalles.Sum(d => d.Producto.Precio * d.Cantidad), // Se usa Producto.Precio directamente
                    UserId = userId,
                    Detalles = detalles
                };

                // Registrar el pedido usando MauiEncargueService
                await _encargueService.AddAsync(nuevoEncargue);

                // Limpiar el carrito después de procesar el pedido
                await ClearCartAsync();

                Console.WriteLine($"Pedido procesado exitosamente. Total: {nuevoEncargue.Total}, Productos: {detalles.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en checkout: {ex.Message}");
                throw new Exception($"Error al procesar el pedido: {ex.Message}", ex);
            }
        }
    }
}