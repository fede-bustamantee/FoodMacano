using FoodMacanoServices.Class;
using FoodMacanoServices.Models;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FoodMacanoServices.Services.Orders
{
    public class DesktopWebService
    {
        private readonly HttpClient _httpClient;
        private readonly string _endpoint;
        private readonly JsonSerializerOptions _options;

        public DesktopWebService()
        {
            _httpClient = new HttpClient();
            _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                ReferenceHandler = ReferenceHandler.Preserve
            };
            var urlApi = Properties.Resources.UrlApi;
            _endpoint = urlApi + ApiEndPoints.GetEndpoint(nameof(ApiEndPoints.Encargue));
        }

        public async Task<List<Encargue>> GetAllEncarguesAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(_endpoint);
                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Error al obtener encargues: {response.StatusCode}");

                return await response.Content.ReadFromJsonAsync<List<Encargue>>(_options) ??
                       new List<Encargue>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener encargues: {ex.Message}");
                return new List<Encargue>();
            }
        }

        public async Task UpdateEncargueAsync(Encargue encargue)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{_endpoint}/{encargue.Id}", encargue);
                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Error al actualizar el encargue: {response.StatusCode}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar encargue: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteEncargueAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{_endpoint}/{id}");
                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Error al eliminar el encargue: {response.StatusCode}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar encargue: {ex.Message}");
                throw;
            }
        }
    }
}
