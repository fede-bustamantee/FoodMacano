using FoodMacanoServices.Class;
using FoodMacanoServices.Models.Common;
using System.Text.Json;

namespace FoodMacanoServices.Services.Common
{
    public class CategoriaService : GenericService<Categoria>
    {
        private readonly HttpClient client;
        private readonly JsonSerializerOptions options;
        private readonly string _endpoint;

        public CategoriaService()
        {
            client = new HttpClient();
            options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            var urlApi = Properties.Resources.UrlApi;
            _endpoint = urlApi + ApiEndPoints.GetEndpoint(nameof(Categoria));
        }

        public async Task<List<Categoria>> GetAllAsync()
        {
            var response = await client.GetAsync(_endpoint);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            return JsonSerializer.Deserialize<List<Categoria>>(content, options);
        }
    }
}