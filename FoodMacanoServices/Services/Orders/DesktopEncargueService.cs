using FoodMacanoServices.Class;
using FoodMacanoServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FoodMacanoServices.Services.Orders
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

        public async Task<bool> EnviarEncarguesAsync(List<DesktopEncargue> encargues)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(_endpoint, encargues);
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Código de estado: {response.StatusCode}");
                Console.WriteLine($"Respuesta: {responseBody}");

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al enviar el encargo: {ex.Message}");
                return false;
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
        public async Task<bool> UpdateEncargueAsync(DesktopEncargue encargue)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{_endpoint}/{encargue.Id}", encargue);
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Código de estado: {response.StatusCode}");
                Console.WriteLine($"Respuesta: {responseBody}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar el encargo: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteEncargueAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{_endpoint}/{id}");
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Código de estado: {response.StatusCode}");
                Console.WriteLine($"Respuesta: {responseBody}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el encargo: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> AddEncargueAsync(DesktopEncargue encargue)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{_endpoint}/single", encargue);
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Código de estado: {response.StatusCode}");
                Console.WriteLine($"Respuesta: {responseBody}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar el encargo: {ex.Message}");
                return false;
            }
        }
        public async Task<DesktopEncargue> GetEncargueByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_endpoint}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<DesktopEncargue>();
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el encargo: {ex.Message}");
                throw;
            }
        }
    }
}
