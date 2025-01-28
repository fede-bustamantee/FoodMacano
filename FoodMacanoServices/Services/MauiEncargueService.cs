using FoodMacanoServices.Class;
using FoodMacanoServices.Interfaces;
using FoodMacanoServices.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace FoodMacanoServices.Services
{
    public class MauiEncargueService : GenericService<MauiEncargue>, IMauiEncargueService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options;
        private readonly string _endpoint;
        private readonly IAuthService _authService;

        public MauiEncargueService(IAuthService authService)
        {
            _httpClient = new HttpClient();
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));

            var urlApi = Properties.Resources.UrlApi;
            _endpoint = urlApi + ApiEndPoints.GetEndpoint(nameof(MauiEncargue));
        }

        private async Task SetAuthHeader()
        {
            var token = await _authService.GetCurrentUserToken();
            if (string.IsNullOrEmpty(token))
                throw new UnauthorizedAccessException("Token de autenticación no disponible");

            _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<List<MauiEncargue>> GetEncarguesAsync(string firebaseUserId)
        {
            try
            {
                await SetAuthHeader();
                var response = await _httpClient.GetAsync($"{_endpoint}/user/{firebaseUserId}");
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                    throw new ApplicationException(content);

                return JsonSerializer.Deserialize<List<MauiEncargue>>(content, _options) ?? new List<MauiEncargue>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener los encargues del usuario {firebaseUserId}", ex);
            }
        }

        public async Task AddEncargueAsync(MauiEncargue encargue)
        {
            if (encargue == null)
                throw new ArgumentNullException(nameof(encargue));

            try
            {
                await SetAuthHeader();
                var response = await _httpClient.PostAsJsonAsync(_endpoint, encargue);
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                    throw new ApplicationException(content);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el encargue", ex);
            }
        }

        public async Task<MauiEncargue> GetEncargueByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor que 0", nameof(id));

            try
            {
                await SetAuthHeader();
                var response = await _httpClient.GetAsync($"{_endpoint}/{id}");
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                    throw new ApplicationException(content);

                var encargue = JsonSerializer.Deserialize<MauiEncargue>(content, _options);
                if (encargue == null)
                    throw new Exception($"No se encontró el encargue con ID {id}");

                return encargue;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener el encargue con ID {id}", ex);
            }
        }

        public async Task UpdateEncargueAsync(MauiEncargue encargue)
        {
            if (encargue == null)
                throw new ArgumentNullException(nameof(encargue));

            if (encargue.Id <= 0)
                throw new ArgumentException("El ID del encargue debe ser mayor que 0", nameof(encargue));

            try
            {
                await SetAuthHeader();
                var response = await _httpClient.PutAsJsonAsync($"{_endpoint}/{encargue.Id}", encargue);
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                    throw new ApplicationException(content);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar el encargue con ID {encargue.Id}", ex);
            }
        }

        public async Task DeleteEncargueAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor que 0", nameof(id));

            try
            {
                await SetAuthHeader();
                var response = await _httpClient.DeleteAsync($"{_endpoint}/{id}");
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                    throw new ApplicationException(content);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar el encargue con ID {id}", ex);
            }
        }
    }
}