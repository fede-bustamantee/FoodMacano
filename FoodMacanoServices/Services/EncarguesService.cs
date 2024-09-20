using FoodMacanoServices.Interfaces;
using FoodMacanoServices.Models;
using System.Net.Http.Json;

namespace FoodMacanoServices.Services
{
    public class EncarguesService : IGenericService<Encargue>
    {
        private readonly HttpClient _httpClient;
        private const string ApiEndpoint = "encargues";

        public EncarguesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Encargue>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Encargue>>(ApiEndpoint);
        }

        public async Task<Encargue> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Encargue>($"{ApiEndpoint}/{id}");
        }

        public async Task<Encargue> AddAsync(Encargue encargue)
        {
            var response = await _httpClient.PostAsJsonAsync(ApiEndpoint, encargue);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Encargue>();
        }

        public async Task UpdateAsync(Encargue encargue)
        {
            var response = await _httpClient.PutAsJsonAsync($"{ApiEndpoint}/{encargue.Id}", encargue);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{ApiEndpoint}/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<Encargue>> GetAleatoriosAsync()
        {
            // Este método no es relevante para Encargues, pero lo implementamos para cumplir con la interfaz
            throw new NotImplementedException();
        }
    }
}