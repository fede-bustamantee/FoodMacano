﻿using FoodMacanoServices.Class;
using FoodMacanoServices.Interfaces;
using FoodMacanoServices.Models;
using System.Linq.Expressions;
using System.Net.Http.Json;
using System.Text.Json;

namespace FoodMacanoServices.Services.Common
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        protected readonly HttpClient client;
        protected readonly JsonSerializerOptions options;
        protected readonly string _endpoint;

        public GenericService(HttpClient client)
        {
            this.client = client;
            options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            _endpoint = ApiEndPoints.GetEndpoint(typeof(T).Name);
        }

        public GenericService()
        {
            client = new HttpClient();
            options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            var urlApi = Properties.Resources.UrlApi;
            _endpoint = urlApi + ApiEndPoints.GetEndpoint(typeof(T).Name);
        }

        // Método para obtener todos los elementos con un filtro de predicado
        public async Task<List<T>?> GetAllAsync(Func<T, bool> predicate)
        {
            var allItems = await GetAllAsync(); // Llama al método para obtener todos los elementos
            if (allItems == null) return null;

            // Aplica el filtro usando el predicate
            var filteredItems = allItems.Where(predicate).ToList();
            return filteredItems;
        }

        // Método para obtener todos los elementos sin filtro
        public async Task<List<T>?> GetAllAsync()
        {
            var response = await client.GetAsync(_endpoint);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content?.ToString());
            }
            return JsonSerializer.Deserialize<List<T>>(content, options);
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            var response = await client.GetAsync($"{_endpoint}/{id}");
            var content = await response.Content.ReadAsStreamAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content?.ToString());
            }
            return JsonSerializer.Deserialize<T>(content, options);
        }

        public async Task<T?> AddAsync(T? entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "La entidad no puede ser nula.");

            try
            {
                var response = await client.PostAsJsonAsync(_endpoint, entity);
                var content = await response.Content.ReadAsStreamAsync();

                if (!response.IsSuccessStatusCode)
                {
                    string errorDetails = await response.Content.ReadAsStringAsync();
                    throw new ApplicationException($"Error en AddAsync: {response.StatusCode}, Detalles: {errorDetails}");
                }

                return JsonSerializer.Deserialize<T>(content, options);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción en AddAsync: {ex.Message}");
                throw;
            }
        }


        public async Task UpdateAsync(T? entity)
        {
            var idValue = entity.GetType().GetProperty("Id").GetValue(entity);

            var response = await client.PutAsJsonAsync($"{_endpoint}/{idValue}", entity);
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(response?.ToString());
            }
        }

        public async Task<bool> ResourceExistsAsync(int id)
        {
            var response = await client.GetAsync($"{_endpoint}/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task DeleteAsync(int id)
        {
            if (!await ResourceExistsAsync(id))
            {
                Console.WriteLine($"El recurso con ID {id} no se encuentra y no se puede eliminar.");
                return;
            }

            var response = await client.DeleteAsync($"{_endpoint}/{id}");
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                throw new ApplicationException($"Error al eliminar el recurso: {response.StatusCode}, Detalles: {content}");
            }
        }

        public async Task<List<T>?> GetRandomAsync(int count)
        {
            var response = await client.GetAsync($"{_endpoint}/aleatorios?count={count}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content?.ToString());
            }
            return JsonSerializer.Deserialize<List<T>>(content, options);
        }
        public async Task<List<T>> GetWithFilterAsync(Expression<Func<T, bool>> filter)
        {
            var allItems = await GetAllAsync();
            if (allItems == null) return new List<T>();

            // Aplica el filtro usando LINQ
            var filteredItems = allItems.AsQueryable().Where(filter).ToList();
            return filteredItems;
        }
    }
}
