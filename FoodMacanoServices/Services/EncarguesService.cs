using System.Text.Json;
using FoodMacanoServices.Models;
using FoodMacanoServices.Class;
using System.Net.Http.Json;
using FoodMacanoServices.Interfaces;

namespace FoodMacanoServices.Services
{
    public class EncargueService : GenericService<Encargue>, IEncargueService
    {
        private readonly HttpClient client;
        private readonly JsonSerializerOptions options;
        private readonly string _endpoint;
        private readonly FirebaseAuthService _authService;
        private readonly UsuarioMappingService _usuarioMappingService;
        private readonly IGenericService<Encargue> _encargueService;

        public EncargueService(
            FirebaseAuthService authService,
            UsuarioMappingService usuarioMappingService,
            IGenericService<Encargue> encargueService)
        {
            client = new HttpClient();
            options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var urlApi = Properties.Resources.UrlApi;
            _endpoint = urlApi + ApiEndPoints.GetEndpoint(nameof(Encargue));
            _authService = authService;
            _usuarioMappingService = usuarioMappingService;
            _encargueService = encargueService;
        }

        public async Task<List<Encargue>> GetEncarguesAsync(string firebaseUserId)
        {
            try
            {
                if (string.IsNullOrEmpty(firebaseUserId))
                {
                    throw new InvalidOperationException("Usuario no autenticado");
                }
                var userId = await _usuarioMappingService.GetUsuarioIdFromFirebaseId(firebaseUserId);
                var response = await client.GetAsync($"{_endpoint}?usuarioId={userId}");
                var content = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    throw new ApplicationException($"Error: {response.StatusCode}, Details: {content}");
                }
                var encargues = JsonSerializer.Deserialize<List<Encargue>>(content, options);
                return encargues ?? new List<Encargue>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetEncarguesAsync: {ex.Message}");
                throw;
            }
        }

        public async Task AddEncargueAsync(Encargue encargue)
        {
            try
            {
                var firebaseId = await _authService.GetUserId();
                if (string.IsNullOrEmpty(firebaseId))
                {
                    throw new InvalidOperationException("Usuario no autenticado");
                }

                var userId = await _usuarioMappingService.GetUsuarioIdFromFirebaseId(firebaseId);
                encargue.UsuarioId = userId;
                encargue.FechaEncargue = DateTime.Now;

                // Limpiar propiedades de navegación
                encargue.Producto = null;
                encargue.Usuario = null;

                var response = await client.PostAsJsonAsync(_endpoint, encargue);
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new ApplicationException($"Error: {response.StatusCode}, Details: {content}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en AddEncargueAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<Encargue> GetEncargueByIdAsync(int id)
        {
            try
            {
                var response = await client.GetAsync($"{_endpoint}/{id}");
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new ApplicationException($"Error: {response.StatusCode}, Details: {content}");
                }

                return JsonSerializer.Deserialize<Encargue>(content, options);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetEncargueByIdAsync: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateEncargueAsync(Encargue encargue)
        {
            try
            {
                var response = await client.PutAsJsonAsync($"{_endpoint}/{encargue.Id}", encargue);
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new ApplicationException($"Error: {response.StatusCode}, Details: {content}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en UpdateEncargueAsync: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteEncargueAsync(int id)
        {
            try
            {
                var response = await client.DeleteAsync($"{_endpoint}/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    throw new ApplicationException($"Error: {response.StatusCode}, Details: {content}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en DeleteEncargueAsync: {ex.Message}");
                throw;
            }
        }
    }
}