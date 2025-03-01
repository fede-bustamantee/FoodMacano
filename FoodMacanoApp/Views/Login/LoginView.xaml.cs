using FoodMacanoApp.ViewModels;
using FoodMacanoServices.Interfaces;
using FoodMacanoServices.Models.FireAuth;
using FoodMacanoServices.Services.FireAuth;
using System.Net.Http.Json;

namespace FoodMacanoApp.Views.Login;

public partial class LoginView : ContentPage
{
    private readonly string _clientId = Properties.Resources.client_id + ".apps.googleusercontent.com";
    private readonly string _redirectUri = $"com.googleusercontent.apps.{Properties.Resources.client_id}:/oauth2redirect";
    private readonly string _authUri = "https://accounts.google.com/o/oauth2/v2/auth";
    private readonly string _tokenUri = "https://oauth2.googleapis.com/token";
    private readonly string _firebaseApiKey = Properties.Resources.ApiKeyGoogleCloud;

    public LoginView()
    {
        InitializeComponent();
        BindingContext = new IniciarSesionViewModel();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Construcción de la URL para la autenticación con Google
            var authUrl = $"{_authUri}?client_id={_clientId}&redirect_uri={_redirectUri}&response_type=code&scope=email%20profile&access_type=offline";

            // Autenticación mediante WebAuthenticator
            var authResult = await WebAuthenticator.AuthenticateAsync(
                new Uri(authUrl),
                new Uri(_redirectUri));

            var authCode = authResult.Properties["code"];
            var accessToken = await ExchangeAuthCodeForToken(authCode);

            try
            {
                // Registro del usuario en Firebase con el token de Google
                var nameUser = await SignInWithGoogleAccessToken(accessToken);
                Console.WriteLine($"Usuario registrado exitosamente en Firebase. Firebase Nombre usuario: {nameUser}");
            }
            catch (HttpRequestException ex)
            {
                // Manejo de errores de autenticación en Firebase
                await DisplayAlert("Error de Autenticación", $"No se pudo registrar al usuario en Firebase: {ex.Message}", "OK");
                Console.WriteLine($"Error al registrar al usuario en Firebase: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Manejo de errores inesperados
                await DisplayAlert("Error Inesperado", $"Ocurrió un error durante el inicio de sesión: {ex.Message}", "OK");
                Console.WriteLine($"Error inesperado: {ex}");
            }
        }
        catch (Exception ex)
        {
            // Manejo de errores generales en la autenticación
            await DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
            Console.WriteLine($"Error general de autenticación: {ex}");
        }
    }

    // Método para intercambiar el código de autorización por un token de acceso
    private async Task<string> ExchangeAuthCodeForToken(string authCode)
    {
        try
        {
            using (var client = new HttpClient())
            {
                var tokenRequest = new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("code", authCode),
                new KeyValuePair<string, string>("client_id", _clientId),
                new KeyValuePair<string, string>("redirect_uri", _redirectUri),
                new KeyValuePair<string, string>("grant_type", "authorization_code"),
            });

                var response = await client.PostAsync(_tokenUri, tokenRequest);

                if (!response.IsSuccessStatusCode)
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error en ExchangeAuthCodeForToken: {errorMessage}");
                    throw new HttpRequestException($"Error en la solicitud del token: {response.ReasonPhrase}");
                }

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var tokenData = System.Text.Json.JsonDocument.Parse(jsonResponse).RootElement;

                if (!tokenData.TryGetProperty("id_token", out var idToken))
                {
                    throw new Exception("La respuesta del servidor no contiene id_token.");
                }

                return idToken.GetString();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error inesperado en ExchangeAuthCodeForToken: {ex.Message}");
            throw;
        }
    }
    // Método para registrar al usuario en Firebase usando el token de acceso de Google
    public async Task<string> SignInWithGoogleAccessToken(string googleAccessToken)
    {
        var firebaseUrl = $"https://identitytoolkit.googleapis.com/v1/accounts:signInWithIdp?key={_firebaseApiKey}";
        var requestData = new
        {
            postBody = $"id_token={googleAccessToken}&providerId=google.com",
            requestUri = "http://localhost",
            returnSecureToken = true
        };

        using var httpClient = new HttpClient();
        var response = await httpClient.PostAsJsonAsync(firebaseUrl, requestData);

        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadFromJsonAsync<FirebaseSignInResponse>();

            if (jsonResponse != null)
            {
                // Obtiene el servicio de autenticación
                var authService = Handler?.MauiContext?.Services?.GetService<IAuthService>() as MauiFirebaseAuthService;

                if (authService != null)
                {
                    Console.WriteLine("Guardando información de usuario después del login con Google");
                    await authService.SetCurrentUser(jsonResponse, "google");
                }
                else
                {
                    Console.WriteLine("Error: No se pudo obtener el servicio de autenticación.");
                    await Shell.Current.DisplayAlert("Error", "No se pudo obtener el servicio de autenticación.", "OK");
                }

                // Habilita la aplicación después del inicio de sesión
                if (App.Current?.MainPage is AppShell appShell)
                {
                    appShell.EnableAppAfterLogin();
                }
                else
                {
                    Console.WriteLine("Error: AppShell es null");
                }

                return jsonResponse.DisplayName; // Retorna el nombre del usuario registrado
            }
            else
            {
                throw new Exception("La respuesta de Firebase fue nula.");
            }
        }
        else
        {
            // Manejo de errores en la respuesta de Firebase
            var errorResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Error en la respuesta de Firebase: {errorResponse}");
            throw new HttpRequestException($"Error al registrar el usuario en Firebase: {response.ReasonPhrase}");
        }
    }
}