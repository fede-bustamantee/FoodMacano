using FoodMacanoServices.Class;
using System.Text.Json;
using System.Net.Http.Json;
using FoodMacanoServices.Models.Common;

namespace FoodMacanoServices.Services.Common
{
    public class NegocioService
    {
        private readonly HttpClient client;
        private readonly JsonSerializerOptions options;
        private readonly string _endpoint;

        public NegocioService()
        {
            client = new HttpClient();
            options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
                ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve
            };
            var urlApi = Properties.Resources.UrlApi;
            _endpoint = urlApi + "/" + ApiEndPoints.GetEndpoint(nameof(ApiEndPoints.Negocio)); // Usando ApiEndPoints
        }

        public async Task<List<Negocio>?> GetAllAsync()
        {
            try
            {
                var response = await client.GetAsync(_endpoint);
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new ApplicationException($"Error al obtener los negocios: {content}");
                }

                if (string.IsNullOrEmpty(content))
                {
                    return new List<Negocio>();
                }

                var negocios = JsonSerializer.Deserialize<List<Negocio>>(content, options);
                return negocios;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error en el servicio: {ex.Message}");
            }
        }

        public async Task<Negocio?> GetByIdAsync(int id)
        {
            try
            {
                var response = await client.GetAsync($"{_endpoint}/{id}");
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        return null;
                    }
                    throw new ApplicationException($"Error al obtener el negocio: {content}");
                }

                return JsonSerializer.Deserialize<Negocio>(content, options);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error en el servicio: {ex.Message}");
            }
        }

        public async Task<Negocio?> AddAsync(Negocio negocio)
        {
            try
            {
                var response = await client.PostAsJsonAsync(_endpoint, negocio);
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new ApplicationException($"Error al agregar el negocio: {content}");
                }

                return JsonSerializer.Deserialize<Negocio>(content, options);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error en el servicio: {ex.Message}");
            }
        }

        public async Task UpdateAsync(Negocio negocio)
        {
            try
            {
                var response = await client.PutAsJsonAsync($"{_endpoint}/{negocio.Id}", negocio);

                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    throw new ApplicationException($"Error al actualizar el negocio: {content}");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error en el servicio: {ex.Message}");
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var response = await client.DeleteAsync($"{_endpoint}/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    throw new ApplicationException($"Error al eliminar el negocio: {content}");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error en el servicio: {ex.Message}");
            }
        }
    }
}