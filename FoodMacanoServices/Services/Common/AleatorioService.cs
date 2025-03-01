using FoodMacanoServices.Class;
using FoodMacanoServices.Interfaces;
using System.Text.Json;

namespace FoodMacanoServices.Services.Common
{
    public class AleatorioService<T> : IAleatorioService<T> where T : class
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;
        private readonly string _endpoint;

        public AleatorioService(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _endpoint = $"{ApiEndPoints.GetEndpoint(typeof(T).Name)}/aleatorios";
        }

        public async Task<List<T>?> GetAleatoriosAsync()
        {
            var response = await _client.GetAsync(_endpoint);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            return JsonSerializer.Deserialize<List<T>>(content, _options);
        }
    }
}
