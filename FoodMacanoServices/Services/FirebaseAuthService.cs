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
                return (userId, isEmailVerified);
            }
            catch (Exception error)
            {
                Console.Error.WriteLine("Error al iniciar sesión:", error);
                return (null, false);
            }
        }

        public async Task<string> RegisterWithEmailPassword(string email, string password)
        {
            try
            {
                var userId = await _jsRuntime.InvokeAsync<string>("firebaseAuth.registerWithEmailPassword", email, password);
                if (!string.IsNullOrEmpty(userId))
                {
                    await _jsRuntime.InvokeVoidAsync("firebaseAuth.sendEmailVerification");
                }
                return userId;
            }
            catch (Exception error)
            {
                Console.Error.WriteLine("Error al registrar usuario:", error);
                return null;
            }
        }

        public async Task<(string firebaseId, string email, string displayName)> SignInWithGoogle()
        {
            try
            {
                var result = await _jsRuntime.InvokeAsync<Usuario>("firebaseAuth.signInWithGoogle");
                return (result.FirebaseId, result.Email, result.User);
            }
            catch (Exception error)
            {
                Console.Error.WriteLine("Error al iniciar sesión con Google:", error);
                return (null, null, null);
            }
        }

        public async Task<(string firebaseId, string email, string displayName)> SignInWithFacebook()
        {
            try
            {
                var result = await _jsRuntime.InvokeAsync<Usuario>("firebaseAuth.signInWithFacebook");
                return (result.FirebaseId, result.Email, result.User);
            }
            catch (Exception error)
            {
                Console.Error.WriteLine("Error al iniciar sesión con Facebook:", error);
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
            return !string.IsNullOrEmpty(userId);
        }
    }
}
