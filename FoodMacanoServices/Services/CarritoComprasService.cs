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
            var firebaseId = await _authService.GetUserId();
            var userId = await _usuarioMappingService.GetUsuarioIdFromFirebaseId(firebaseId);

            return await _carritoService.GetAllAsync(c => c.UsuarioId == userId) ?? new List<CarritoCompra>();
        }
        public async Task RemoveFromCartAsync(int itemId)
        {
            await _carritoService.DeleteAsync(itemId);
        }
        public async Task AddToCartAsync(Producto producto)
        {
            // Obtén el ID del usuario autenticado
            var firebaseId = await _authService.GetUserId();
            var userId = await _usuarioMappingService.GetUsuarioIdFromFirebaseId(firebaseId);

            if (userId <= 0)
            {
                throw new InvalidOperationException("El ID de usuario no es válido.");
            }

            // Crea un objeto simplificado con solo los campos necesarios
            var newItem = new CarritoCompra
            {
                ProductoId = producto.Id,
                Cantidad = 1,
                UsuarioId = userId
            };

            // Depuración: Imprime el objeto antes de enviarlo
            Console.WriteLine($"Datos enviados: {JsonSerializer.Serialize(newItem)}");

            // Llama a AddAsync para enviar el objeto a la API
            await _carritoService.AddAsync(newItem);
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
