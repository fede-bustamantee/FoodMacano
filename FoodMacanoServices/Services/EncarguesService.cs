using System.Text.Json;
using FoodMacanoServices.Models;
using FoodMacanoServices.Class;
using System.Net.Http.Json;
using FoodMacanoServices.Interfaces;

namespace FoodMacanoServices.Services
{
    public class EncargueService : GenericService<Encargue>, IEncargueService
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;
        private readonly string _endpoint;
        private readonly FirebaseAuthService _authService;
        private readonly UsuarioMappingService _usuarioMappingService;

        public EncargueService(
            HttpClient client,
            FirebaseAuthService authService,
            UsuarioMappingService usuarioMappingService) : base(client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
            _usuarioMappingService = usuarioMappingService ?? throw new ArgumentNullException(nameof(usuarioMappingService));
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            // Configuración del endpoint
            var urlApi = Properties.Resources.UrlApi ?? throw new InvalidOperationException("UrlApi no configurado.");
            _endpoint = urlApi + ApiEndPoints.GetEndpoint(nameof(Encargue));
        }

        public async Task<List<Encargue>> GetEncarguesAsync(string firebaseUserId)
        {
            if (string.IsNullOrEmpty(firebaseUserId))
                throw new ArgumentException("Firebase User ID no puede ser nulo o vacío.");

            try
            {
                var userId = await _usuarioMappingService.GetUsuarioIdFromFirebaseId(firebaseUserId);
                var response = await _client.GetAsync($"{_endpoint}?usuarioId={userId}");

                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<List<Encargue>>(content, _options) ?? new List<Encargue>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetEncarguesAsync: {ex.Message}");
                throw;
            }
        }

        public async Task AddEncargueAsync(Encargue encargue)
        {
            if (encargue == null)
                throw new ArgumentNullException(nameof(encargue), "El encargue no puede ser nulo.");

            try
            {
                var firebaseId = await _authService.GetUserId();
                if (string.IsNullOrEmpty(firebaseId))
                    throw new InvalidOperationException("Usuario no autenticado.");

                var userId = await _usuarioMappingService.GetUsuarioIdFromFirebaseId(firebaseId);
                encargue.UsuarioId = userId;
                encargue.FechaEncargue = DateTime.UtcNow;

                // Limpiar propiedades innecesarias
                encargue.Producto = null;
                encargue.Usuario = null;

                var response = await _client.PostAsJsonAsync(_endpoint, encargue);
                response.EnsureSuccessStatusCode(); // Lanza una excepción si el código HTTP no indica éxito
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en AddEncargueAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<Encargue> GetEncargueByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor a cero.");

            try
            {
                var response = await _client.GetAsync($"{_endpoint}/{id}");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Encargue>(content, _options);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetEncargueByIdAsync: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateEncargueAsync(Encargue encargue)
        {
            if (encargue == null || encargue.Id <= 0)
                throw new ArgumentException("Encargue inválido para actualizar.");

            try
            {
                var response = await _client.PutAsJsonAsync($"{_endpoint}/{encargue.Id}", encargue);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en UpdateEncargueAsync: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteEncargueAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor a cero.");

            try
            {
                var response = await _client.DeleteAsync($"{_endpoint}/{id}");
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en DeleteEncargueAsync: {ex.Message}");
                throw;
            }
        }
    }
}
