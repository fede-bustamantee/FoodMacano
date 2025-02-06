using FoodMacanoServices.Class;
using FoodMacanoServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FoodMacanoServices.Services
{
    public class DesktopEncargueService
    {
        private readonly HttpClient _httpClient;
        private readonly string _endpoint;

        public DesktopEncargueService()
        {
            _httpClient = new HttpClient();
            var urlApi = Properties.Resources.UrlApi;
            _endpoint = urlApi + ApiEndPoints.GetEndpoint(nameof(DesktopEncargue));
        }

        public async Task<bool> EnviarEncargueAsync(DesktopEncargue encargue)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(_endpoint, encargue);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al enviar el encargue: {ex.Message}");
                throw;
            }
        }

        public async Task<List<DesktopEncargue>> GetEncarguesAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(_endpoint);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<DesktopEncargue>>();
                }
                return new List<DesktopEncargue>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener encargues: {ex.Message}");
                throw;
            }
        }
    }
}
