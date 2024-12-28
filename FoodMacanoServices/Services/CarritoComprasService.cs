using FoodMacanoServices.Interfaces;
using FoodMacanoServices.Models;
using System.Text.Json;

namespace FoodMacanoServices.Services
{
    public class CarritoComprasService
    {
        private readonly IGenericService<CarritoCompra> _carritoService;
        private readonly IGenericService<Encargue> _encargueService;
        private readonly FirebaseAuthService _authService;
        private readonly UsuarioMappingService _usuarioMappingService;

        public CarritoComprasService(
            IGenericService<CarritoCompra> carritoService,
            IGenericService<Encargue> encargueService,
            FirebaseAuthService authService,
            UsuarioMappingService usuarioMappingService)
        {
            _carritoService = carritoService;
            _encargueService = encargueService;
            _authService = authService;
            _usuarioMappingService = usuarioMappingService;
        }
        public async Task<List<CarritoCompra>> GetCartItemsAsync()
        {
            try
            {
                var firebaseId = await _authService.GetUserId();
                var userId = await _usuarioMappingService.GetUsuarioIdFromFirebaseId(firebaseId);
                var items = await _carritoService.GetAllAsync(c => c.UsuarioId == userId);
                return items ?? new List<CarritoCompra>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetCartItemsAsync: {ex.Message}");
                return new List<CarritoCompra>();
            }
        }

        public async Task AddToCartAsync(Producto producto)
        {
            try
            {
                // Obtener el FirebaseId del usuario actual
                var firebaseId = await _authService.GetUserId();
                if (string.IsNullOrEmpty(firebaseId))
                {
                    throw new InvalidOperationException("Usuario no autenticado");
                }

                // Obtener el ID del usuario desde la base de datos
                var userId = await _usuarioMappingService.GetUsuarioIdFromFirebaseId(firebaseId);

                // Verificar si el producto ya existe en el carrito
                var cartItems = await GetCartItemsAsync();
                var existingItem = cartItems.FirstOrDefault(i => i.ProductoId == producto.Id);

                if (existingItem != null)
                {
                    // Si el producto ya existe, incrementar la cantidad
                    existingItem.Cantidad += 1;
                    await _carritoService.UpdateAsync(existingItem);
                }
                else
                {
                    // Si el producto no existe, crear nuevo item
                    var newItem = new CarritoCompra
                    {
                        ProductoId = producto.Id,
                        Cantidad = 1,
                        UsuarioId = userId
                    };
                    await _carritoService.AddAsync(newItem);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en AddToCartAsync: {ex.Message}");
                throw new ApplicationException($"Error al agregar al carrito: {ex.Message}");
            }
        }

        public async Task RemoveFromCartAsync(int itemId)
        {
            try
            {
                await _carritoService.DeleteAsync(itemId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en RemoveFromCartAsync: {ex.Message}");
                throw new ApplicationException($"Error al eliminar del carrito: {ex.Message}");
            }
        }

        public async Task CheckoutAsync()
        {
            var userId = await _authService.GetUserId();
            var cartItems = await GetCartItemsAsync();

            foreach (var item in cartItems)
            {
                var encargue = new Encargue
                {
                    ProductoId = item.ProductoId,
                    UsuarioId = int.Parse(userId),
                    Cantidad = item.Cantidad,
                    FechaEncargue = DateTime.Now
                };

                await _encargueService.AddAsync(encargue);
                await _carritoService.DeleteAsync(item.Id);
            }
        }

        public async Task UpdateAsync(CarritoCompra carritoCompra)
        {
            await _carritoService.UpdateAsync(carritoCompra);
        }

        public async Task<int> GetTotalItemCountAsync()
        {
            var cartItems = await GetCartItemsAsync();
            return cartItems.Sum(item => item.Cantidad);
        }

        public async Task<int> GetUniqueItemCountAsync()
        {
            var cartItems = await GetCartItemsAsync();
            return cartItems.Count;
        }
    }
}
