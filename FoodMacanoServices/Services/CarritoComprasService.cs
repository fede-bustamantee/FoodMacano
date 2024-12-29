using FoodMacanoServices.Class;
using FoodMacanoServices.Interfaces;
using FoodMacanoServices.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace FoodMacanoServices.Services
{
    public class CarritoService : GenericService<CarritoCompra>, ICarritoService
    {
        private readonly HttpClient client;
        private readonly JsonSerializerOptions options;
        private readonly string _endpoint;
        private readonly FirebaseAuthService _authService;
        private readonly UsuarioMappingService _usuarioMappingService;
        private readonly IGenericService<CarritoCompra> _carritoService;
        private readonly string _encarguesEndpoint;

        public CarritoService(
            FirebaseAuthService authService,
            UsuarioMappingService usuarioMappingService,
            IGenericService<CarritoCompra> carritoService,
            IGenericService<Encargue> encargueService)
        {
            client = new HttpClient();
            options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            var urlApi = Properties.Resources.UrlApi;
            _endpoint = urlApi + ApiEndPoints.GetEndpoint(nameof(CarritoCompra));
            _encarguesEndpoint = urlApi + ApiEndPoints.GetEndpoint(nameof(Encargue));
            _authService = authService;
            _usuarioMappingService = usuarioMappingService;
            _carritoService = carritoService;
        }

        public async Task<List<CarritoCompra>> GetCartItemsAsync()
        {
            try
            {
                var firebaseId = await _authService.GetUserId();
                if (string.IsNullOrEmpty(firebaseId))
                {
                    throw new InvalidOperationException("Usuario no autenticado");
                }

                var userId = await _usuarioMappingService.GetUsuarioIdFromFirebaseId(firebaseId);
                var response = await client.GetAsync($"{_endpoint}?usuarioId={userId}");
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new ApplicationException($"Error: {response.StatusCode}, Details: {content}");
                }

                var items = JsonSerializer.Deserialize<List<CarritoCompra>>(content, options);
                return items ?? new List<CarritoCompra>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetCartItemsAsync: {ex.Message}");
                throw;
            }
        }

        public async Task AddToCartAsync(Producto producto)
        {
            try
            {
                var firebaseId = await _authService.GetUserId();
                if (string.IsNullOrEmpty(firebaseId))
                {
                    throw new InvalidOperationException("Usuario no autenticado");
                }

                var userId = await _usuarioMappingService.GetUsuarioIdFromFirebaseId(firebaseId);

                var cartItems = await GetCartItemsAsync();
                var existingItem = cartItems.FirstOrDefault(i => i.ProductoId == producto.Id);

                if (existingItem != null)
                {
                    existingItem.Cantidad++;
                    await UpdateCartItemAsync(existingItem);
                }
                else
                {
                    var newItem = new CarritoCompra
                    {
                        ProductoId = producto.Id,
                        Cantidad = 1,
                        UsuarioId = userId
                    };

                    var response = await client.PostAsJsonAsync(_endpoint, newItem);
                    var content = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        throw new ApplicationException($"Error: {response.StatusCode}, Details: {content}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en AddToCartAsync: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateCartItemAsync(CarritoCompra item)
        {
            try
            {
                var response = await client.PutAsJsonAsync($"{_endpoint}/{item.Id}", item);
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new ApplicationException($"Error: {response.StatusCode}, Details: {content}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en UpdateCartItemAsync: {ex.Message}");
                throw;
            }
        }

        public async Task RemoveFromCartAsync(int itemId)
        {
            try
            {
                var response = await client.DeleteAsync($"{_endpoint}/{itemId}");
                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    throw new ApplicationException($"Error: {response.StatusCode}, Details: {content}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en RemoveFromCartAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<int> GetCartItemCountAsync()
        {
            try
            {
                var items = await GetCartItemsAsync();
                return items.Sum(item => item.Cantidad);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetCartItemCountAsync: {ex.Message}");
                return 0;
            }
        }
        public async Task CheckoutAsync()
        {
            try
            {
                var firebaseId = await _authService.GetUserId();
                if (string.IsNullOrEmpty(firebaseId))
                    throw new InvalidOperationException("Usuario no autenticado.");

                var userId = await _usuarioMappingService.GetUsuarioIdFromFirebaseId(firebaseId);
                var cartItems = await GetCartItemsAsync();

                if (!cartItems.Any())
                    throw new InvalidOperationException("El carrito está vacío. No se puede realizar el checkout.");

                foreach (var item in cartItems)
                {
                    if (item.ProductoId <= 0)
                        throw new InvalidOperationException("El producto en el carrito no es válido.");

                    var encargue = new
                    {
                        ProductoId = item.ProductoId,
                        UsuarioId = userId,
                        Cantidad = item.Cantidad,
                        FechaEncargue = DateTime.Now
                    };

                    try
                    {
                        // Usar el endpoint de encargues y asegurar que se envían los campos requeridos
                        var response = await client.PostAsJsonAsync(_encarguesEndpoint, encargue);

                        if (!response.IsSuccessStatusCode)
                        {
                            var errorContent = await response.Content.ReadAsStringAsync();
                            throw new ApplicationException($"Error al crear el encargue: {response.StatusCode}, Detalles: {errorContent}");
                        }

                        // Si el encargue se creó exitosamente, eliminar el item del carrito
                        await RemoveFromCartAsync(item.Id);
                    }
                    catch (Exception ex)
                    {
                        throw new ApplicationException($"Error procesando el item del carrito {item.Id}: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en CheckoutAsync: {ex.Message}");
                throw;
            }
        }
        public async Task<int> GetUniqueItemCountAsync()
        {
            try
            {
                var cartItems = await GetCartItemsAsync();
                return cartItems.Count;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetUniqueItemCountAsync: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateAsync(CarritoCompra carritoCompra)
        {
            try
            {
                await UpdateCartItemAsync(carritoCompra);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en UpdateAsync: {ex.Message}");
                throw;
            }
        }
    }
}
