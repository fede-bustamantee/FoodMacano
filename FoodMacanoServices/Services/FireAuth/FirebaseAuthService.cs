using FoodMacanoServices.Models;
using Microsoft.JSInterop;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace FoodMacanoServices.Services.FireAuth
{
    public class FirebaseAuthService
    {
        private readonly IJSRuntime _jsRuntime;
        private const string UserIdKey = "firebaseUserId";

        public event Action OnChangeLogin;

        public FirebaseAuthService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task<bool> SetPersistence(bool rememberMe)
        {
            try
            {
                return await _jsRuntime.InvokeAsync<bool>("firebaseAuth.setPersistence", rememberMe ? "local" : "session");
            }
            catch (Exception error)
            {
                Console.Error.WriteLine($"Error setting persistence: {error}");
                return false;
            }
        }

        public async Task<(string userId, bool isEmailVerified)> SignInWithEmailPassword(string email, string password, bool rememberMe)
        {
            try
            {
                await SetPersistence(rememberMe);
                var result = await _jsRuntime.InvokeAsync<JsonElement>("firebaseAuth.signInWithEmailPassword", email, password);

                // Deserializar la respuesta
                if (result.TryGetProperty("success", out JsonElement successElement))
                {
                    bool success = successElement.GetBoolean();

                    if (success)
                    {
                        string userId = result.GetProperty("userId").GetString();
                        bool emailVerified = result.GetProperty("emailVerified").GetBoolean();

                        if (!string.IsNullOrEmpty(userId))
                        {
                            await _jsRuntime.InvokeVoidAsync("localStorageHelper.setItem", UserIdKey, userId);
                            return (userId, emailVerified);
                        }
                    }
                }

                // Si llegamos aquí, algo falló
                string errorMessage = result.TryGetProperty("error", out JsonElement errorElement)
                    ? errorElement.GetString()
                    : "Error desconocido durante la autenticación";

                Console.WriteLine($"Error de autenticación: {errorMessage}");
                return (null, false);
            }
            catch (Exception error)
            {
                Console.WriteLine($"Error durante la autenticación: {error.Message}");
                return (null, false);
            }
        }

        public async Task<(string UserId, bool IsEmailVerified)> GetCurrentUser()
        {
            try
            {
                var result = await _jsRuntime.InvokeAsync<JsonElement>("firebaseAuth.getCurrentUser");

                if (result.ValueKind == JsonValueKind.Null)
                {
                    return (null, false);
                }

                string userId = result.GetProperty("uid").GetString() ?? string.Empty;
                bool isEmailVerified = result.TryGetProperty("emailVerified", out JsonElement emailVerifiedElement)
                    && emailVerifiedElement.ValueKind == JsonValueKind.True
                    || emailVerifiedElement.ValueKind == JsonValueKind.String && bool.TryParse(emailVerifiedElement.GetString(), out bool parsedValue) && parsedValue;

                return (userId, isEmailVerified);
            }
            catch (Exception error)
            {
                Console.Error.WriteLine($"Error getting current user: {error}");
                return (null, false);
            }
        }



        public async Task<string> RegisterWithEmailPassword(string email, string password)
        {
            try
            {
                // Registrar usuario en Firebase
                var userId = await _jsRuntime.InvokeAsync<string>("firebaseAuth.registerWithEmailPassword", email, password);

                if (string.IsNullOrEmpty(userId))
                {
                    throw new Exception("No se pudo crear el usuario en Firebase");
                }

                // El correo de verificación se envía automáticamente en el método registerWithEmailPassword de JavaScript
                return userId;
            }
            catch (Exception error)
            {
                Console.Error.WriteLine($"Error al registrar usuario: {error}");
                throw; // Relanzamos la excepción para manejarla en el componente
            }
        }

        public async Task<bool> ResendVerificationEmail()
        {
            try
            {
                return await _jsRuntime.InvokeAsync<bool>("firebaseAuth.sendEmailVerification");
            }
            catch (Exception error)
            {
                Console.Error.WriteLine($"Error al reenviar correo de verificación: {error}");
                return false;
            }
        }

        public async Task<bool> CheckEmailVerification()
        {
            try
            {
                return await _jsRuntime.InvokeAsync<bool>("firebaseAuth.isEmailVerified");
            }
            catch (Exception error)
            {
                Console.Error.WriteLine($"Error al verificar estado del correo: {error}");
                return false;
            }
        }

        public async Task<(string firebaseId, string email, string displayName)> SignInWithGoogle()
        {
            try
            {
                var result = await _jsRuntime.InvokeAsync<Usuario>("firebaseAuth.signInWithGoogle");

                if (result != null && !string.IsNullOrEmpty(result.FirebaseId))
                {
                    await _jsRuntime.InvokeVoidAsync("localStorageHelper.setItem", UserIdKey, result.FirebaseId);
                    return (result.FirebaseId, result.Email, result.User);
                }
                else
                {
                    Console.WriteLine("No se obtuvo un resultado válido de la autenticación.");
                    return (null, null, null);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error durante la autenticación con Google: {ex.Message}");
                return (null, null, null);
            }
        }

        public async Task SignOut()
        {
            await _jsRuntime.InvokeVoidAsync("firebaseAuth.signOut");
            await _jsRuntime.InvokeVoidAsync("localStorageHelper.removeItem", UserIdKey);
            OnChangeLogin?.Invoke();
        }

        public async Task<string> GetUserId()
        {
            return await _jsRuntime.InvokeAsync<string>("localStorageHelper.getItem", UserIdKey);
        }

        public async Task<bool> IsUserAuthenticated()
        {
            var userId = await GetUserId();
            if (!string.IsNullOrEmpty(userId))
            {
                var isEmailVerified = await CheckEmailVerification();
                return isEmailVerified;
            }
            return false;
        }
        public async Task<bool> ResetPassword(string email)
        {
            try
            {
                await _jsRuntime.InvokeVoidAsync("firebaseAuth.resetPassword", email);
                return true;
            }
            catch (Exception error)
            {
                Console.Error.WriteLine($"Error al enviar el correo de restablecimiento de contraseña: {error}");
                return false;
            }
        }

    }
}