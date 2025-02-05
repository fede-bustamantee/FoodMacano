using FoodMacanoApp.ViewModels;
using FoodMacanoServices.Interfaces;
using FoodMacanoServices.Models;
using FoodMacanoServices.Services;
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
            var authUrl = $"{_authUri}?client_id={_clientId}&redirect_uri={_redirectUri}&response_type=code&scope=email%20profile&access_type=offline";

            var authResult = await WebAuthenticator.AuthenticateAsync(
                new Uri(authUrl),
                new Uri(_redirectUri));

            var authCode = authResult.Properties["code"];
            var accessToken = await ExchangeAuthCodeForToken(authCode);

            try
            {
                var nameUser = await SignInWithGoogleAccessToken(accessToken);
                Console.WriteLine($"Usuario registrado exitosamente en Firebase. Firebase Nombre usuario: {nameUser}");
            }
            catch (HttpRequestException ex)
            {
                await DisplayAlert("Error de Autenticación",
                    $"No se pudo registrar al usuario en Firebase: {ex.Message}",
                    "OK");
                Console.WriteLine($"Error al registrar al usuario en Firebase: {ex.Message}");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error Inesperado",
                    $"Ocurrió un error durante el inicio de sesión: {ex.Message}",
                    "OK");
                Console.WriteLine($"Error inesperado: {ex}");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
            Console.WriteLine($"Error general de autenticación: {ex}");
        }
    }

    // Método para intercambiar el código de autorización por un token de acceso
    private async Task<string> ExchangeAuthCodeForToken(string authCode)
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
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var tokenData = System.Text.Json.JsonDocument.Parse(jsonResponse).RootElement;

            return tokenData.GetProperty("id_token").GetString();
        }
    }
    // Método para registrar al usuario en Firebase usando el access token de Google
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
                var authService = Handler.MauiContext.Services.GetService<IAuthService>() as MauiFirebaseAuthService;

                if (authService != null)
                {
                    Console.WriteLine("Guardando información de usuario después del login con Google");
                    await authService.SetCurrentUser(jsonResponse, "google");
                }
                else
                {
                    Console.WriteLine("Error: No se pudo obtener el servicio de autenticación");
                }

                var institutoShell = (AppShell)App.Current.MainPage;
                institutoShell.EnableAppAfterLogin();

                return jsonResponse.DisplayName;
            }
            else
            {
                throw new Exception("La respuesta de Firebase fue nula");
            }
        }
        else
        {
            var errorResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Error en la respuesta de Firebase: {errorResponse}");
            throw new HttpRequestException($"Error al registrar el usuario en Firebase: {response.ReasonPhrase}");
        }
    }
}