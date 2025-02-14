using FoodMacanoServices.Class;
using FoodMacanoServices.Models;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FoodMacanoServices.Services
{
    public class DesktopMovilService
    {
        private readonly HttpClient _httpClient;
        private readonly string _endpoint;
        private readonly JsonSerializerOptions _options;

        public DesktopMovilService()
        {
            _httpClient = new HttpClient();
            _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                ReferenceHandler = ReferenceHandler.Preserve
            };
            var urlApi = Properties.Resources.UrlApi;
            _endpoint = urlApi + ApiEndPoints.GetEndpoint(nameof(ApiEndPoints.MauiEncargue));
        }
        public async Task<List<MauiEncargue>> GetAllEncarguesAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(_endpoint);
                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Error al obtener encargues: {response.StatusCode}");

                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<MauiEncargue>>(content, _options) ??
                       new List<MauiEncargue>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener encargues: {ex.Message}");
                return new List<MauiEncargue>();
            }
        }
        public async Task UpdateEncargueAsync(MauiEncargue encargue)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_endpoint}/{encargue.Id}", encargue);
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error al actualizar el encargue: {response.StatusCode}");
        }

        public async Task DeleteEncargueAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_endpoint}/{id}");
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error al eliminar el encargue: {response.StatusCode}");
        }
    }
}