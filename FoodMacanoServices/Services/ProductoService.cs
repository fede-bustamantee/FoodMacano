using FoodMacanoServices.Class;
using FoodMacanoServices.Interfaces;
using FoodMacanoServices.Models;
using System.Text.Json;

namespace FoodMacanoServices.Services
{
    public class ProductoService : GenericService<Producto>, IProductoService
    {
        private readonly HttpClient client;
        private readonly JsonSerializerOptions options;
        private readonly string _endpoint;

        public ProductoService()
        {
            client = new HttpClient();
            options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            var urlApi = Properties.Resources.UrlApi;
            _endpoint = urlApi + ApiEndPoints.GetEndpoint(nameof(Producto));
        }

        public async Task<List<Producto>?> GetByCategoriaAsync(int? idCategoria)
        {
            var response = await client.GetAsync($"{_endpoint}?idCategoria={idCategoria}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            return JsonSerializer.Deserialize<List<Producto>>(content, options);
        }
    }
}
