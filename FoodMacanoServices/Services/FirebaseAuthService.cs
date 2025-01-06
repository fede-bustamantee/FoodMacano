using FoodMacanoServices.Models;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace FoodMacanoServices.Services
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

        public async Task<(string userId, bool isEmailVerified)> SignInWithEmailPassword(string email, string password)
        {
            try
            {
                var userId = await _jsRuntime.InvokeAsync<string>("firebaseAuth.signInWithEmailPassword", email, password);
                var isEmailVerified = await _jsRuntime.InvokeAsync<bool>("firebaseAuth.isEmailVerified");

                if (!string.IsNullOrEmpty(userId))
                {
                    await _jsRuntime.InvokeVoidAsync("localStorageHelper.setItem", UserIdKey, userId);
                }

                return (userId, isEmailVerified);
            }
            catch (Exception error)
            {
                Console.Error.WriteLine($"Error al iniciar sesión: {error}");
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
    }
}