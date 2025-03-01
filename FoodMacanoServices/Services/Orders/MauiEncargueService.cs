using FoodMacanoServices.Class;
using FoodMacanoServices.Interfaces;
using FoodMacanoServices.Models.Orders;
using FoodMacanoServices.Services.Common;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FoodMacanoServices.Services.Orders
{
    public class MauiEncargueService : GenericService<MauiEncargue>, IMauiEncargueService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options;
        private readonly string _endpoint;
        private readonly IAuthService _authService;

        public MauiEncargueService(IAuthService authService)
        {
            _httpClient = new HttpClient(); 
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));

            var urlApi = Properties.Resources.UrlApi;
            _endpoint = urlApi + ApiEndPoints.GetEndpoint(nameof(MauiEncargue));
        }

        // Método para establecer el encabezado de autorización con el token de autenticación
        private async Task SetAuthHeader()
        {
            var token = await _authService.GetCurrentUserToken(); // Obtiene el token de autenticación del servicio de autenticación

            // Si el token está vacío, lanza una excepción
            if (string.IsNullOrEmpty(token))
                throw new UnauthorizedAccessException("Token de autenticación no disponible");

            // Establece el encabezado de autorización en las solicitudes HTTP
            _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }

        // Método para obtener la lista de encargues de un usuario por su ID de Firebase
        public async Task<List<MauiEncargue>> GetEncarguesAsync(string firebaseUserId)
        {
            try
            {
                await SetAuthHeader(); // Establece el encabezado de autorización

                // Realiza la solicitud HTTP para obtener los encargues
                var response = await _httpClient.GetAsync($"{_endpoint}/user/{firebaseUserId}");
                var content = await response.Content.ReadAsStringAsync(); // Lee la respuesta en formato de texto

                // Si la respuesta no es exitosa, lanza una excepción
                if (!response.IsSuccessStatusCode)
                {
                    throw new ApplicationException($"Error al obtener encargues: {response.StatusCode}");
                }

                // Deserializa el contenido JSON en una lista de encargues
                return JsonSerializer.Deserialize<List<MauiEncargue>>(content, _options)
                    ?? new List<MauiEncargue>(); // Si no se puede deserializar, devuelve una lista vacía
            }
            catch (Exception ex)
            {
                // Si ocurre un error, lo imprime y lanza la excepción
                Console.WriteLine($"Error al obtener los encargues del usuario {firebaseUserId}: {ex}");
                throw;
            }
        }

        // Método para agregar un nuevo encargue
        public async Task AddEncargueAsync(MauiEncargue encargue)
        {
            if (encargue == null) // Verifica si el encargue es nulo
                throw new ArgumentNullException(nameof(encargue));

            try
            {
                await SetAuthHeader(); // Establece el encabezado de autorización

                // Verifica que la dirección no esté vacía
                if (string.IsNullOrWhiteSpace(encargue.Direccion))
                {
                    throw new ArgumentException("La dirección no puede estar vacía.");
                }

                // Realiza la solicitud POST para crear el encargue
                var response = await _httpClient.PostAsJsonAsync(_endpoint, encargue);
                var content = await response.Content.ReadAsStringAsync(); // Lee la respuesta en formato de texto

                // Si la respuesta no es exitosa, lanza una excepción con el mensaje de error
                if (!response.IsSuccessStatusCode)
                    throw new ApplicationException(content);
            }
            catch (Exception ex)
            {
                // Si ocurre un error, lo lanza en un nuevo mensaje de excepción
                throw new Exception("Error al crear el encargue", ex);
            }
        }

        // Método para obtener un encargue por su ID
        public async Task<MauiEncargue> GetEncargueByIdAsync(int id)
        {
            if (id <= 0) // Verifica que el ID sea válido
                throw new ArgumentException("El ID debe ser mayor que 0", nameof(id));

            try
            {
                await SetAuthHeader(); // Establece el encabezado de autorización

                // Realiza la solicitud GET para obtener el encargue por su ID
                var response = await _httpClient.GetAsync($"{_endpoint}/{id}");
                var content = await response.Content.ReadAsStringAsync(); // Lee la respuesta en formato de texto

                // Si la respuesta no es exitosa, lanza una excepción con el contenido del error
                if (!response.IsSuccessStatusCode)
                    throw new ApplicationException(content);

                // Deserializa el contenido JSON en un objeto MauiEncargue
                var encargue = JsonSerializer.Deserialize<MauiEncargue>(content, _options);

                if (encargue == null)
                    throw new Exception($"No se encontró el encargue con ID {id}"); // Si el encargue es nulo, lanza una excepción

                return encargue; // Devuelve el encargue encontrado
            }
            catch (Exception ex)
            {
                // Si ocurre un error, lanza una excepción
                throw new Exception($"Error al obtener el encargue con ID {id}", ex);
            }
        }

        // Método para actualizar un encargue existente
        public async Task UpdateEncargueAsync(MauiEncargue encargue)
        {
            if (encargue == null) // Verifica si el encargue es nulo
                throw new ArgumentNullException(nameof(encargue));

            if (encargue.Id <= 0) // Verifica que el ID del encargue sea válido
                throw new ArgumentException("El ID del encargue debe ser mayor que 0", nameof(encargue));

            try
            {
                await SetAuthHeader(); // Establece el encabezado de autorización

                // Realiza la solicitud PUT para actualizar el encargue
                var response = await _httpClient.PutAsJsonAsync($"{_endpoint}/{encargue.Id}", encargue);
                var content = await response.Content.ReadAsStringAsync(); // Lee la respuesta en formato de texto

                // Si la respuesta no es exitosa, lanza una excepción con el mensaje de error
                if (!response.IsSuccessStatusCode)
                    throw new ApplicationException(content);
            }
            catch (Exception ex)
            {
                // Si ocurre un error, lanza una excepción con un mensaje de error específico
                throw new Exception($"Error al actualizar el encargue con ID {encargue.Id}", ex);
            }
        }

        // Método para eliminar un encargue por su ID
        public async Task DeleteEncargueAsync(int id)
        {
            if (id <= 0) // Verifica que el ID sea válido
                throw new ArgumentException("El ID debe ser mayor que 0", nameof(id));

            try
            {
                await SetAuthHeader(); // Establece el encabezado de autorización

                // Realiza la solicitud DELETE para eliminar el encargue por su ID
                var response = await _httpClient.DeleteAsync($"{_endpoint}/{id}");
                var content = await response.Content.ReadAsStringAsync(); // Lee la respuesta en formato de texto

                // Si la respuesta no es exitosa, lanza una excepción con el contenido del error
                if (!response.IsSuccessStatusCode)
                    throw new ApplicationException(content);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar el encargue con ID {id}", ex);
            }
        }
        public async Task<List<MauiEncargue>> GetEncarguesConDetallesAsync(string userId)
        {
            try
            {
                await SetAuthHeader(); // Establece el encabezado de autorización

                // Realiza la solicitud GET para obtener los encargues con detalles
                var response = await _httpClient.GetAsync($"{_endpoint}/user/{userId}/withDetails");

                if (!response.IsSuccessStatusCode)
                    throw new HttpRequestException($"Error al obtener encargues: {response.StatusCode}");

                var content = await response.Content.ReadAsStringAsync(); // Lee la respuesta en formato de texto
                return JsonSerializer.Deserialize<List<MauiEncargue>>(content, _options) ??
                       new List<MauiEncargue>(); // Devuelve la lista de encargues deserializada
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener encargues con detalles: {ex.Message}");
                throw;
            }
        }

        // Método para obtener los detalles de un encargue específico por su ID
        public async Task<MauiEncargue> GetEncargueConDetallesAsync(int encargueId)
        {
            try
            {
                await SetAuthHeader(); // Establece el encabezado de autorización

                // Realiza la solicitud GET para obtener el encargue con detalles
                var response = await _httpClient.GetAsync($"{_endpoint}/{encargueId}/details");

                if (!response.IsSuccessStatusCode)
                    throw new HttpRequestException($"Error al obtener encargue: {response.StatusCode}");

                var content = await response.Content.ReadAsStringAsync(); // Lee la respuesta en formato de texto
                var encargue = JsonSerializer.Deserialize<MauiEncargue>(content, _options);

                if (encargue == null)
                    throw new Exception($"No se encontró el encargue con ID {encargueId}"); // Si el encargue es nulo, lanza una excepción

                return encargue; // Devuelve el encargue con detalles
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener encargue con detalles: {ex.Message}");
                throw;
            }
        }
    }
}