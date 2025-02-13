using FoodMacanoServices.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace FoodMacanoServices.Models
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

                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Encargue>>(content, _options) ??
                       new List<Encargue>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener encargues: {ex.Message}");
                return new List<Encargue>();
            }
        }
    }
}
