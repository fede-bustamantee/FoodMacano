using Firebase.Auth;
using Firebase.Auth.Repository;
using FoodMacanoServices.Interfaces;
using FoodMacanoServices.Models;
using Microsoft.Maui.Storage;

namespace FoodMacanoServices.Services
{
    public class MauiFirebaseAuthService : IAuthService
    {
        private readonly FirebaseAuthClient _firebaseAuth;
        private FirebaseSignInResponse _currentUser;
        private readonly IPreferences _preferences;

        private const string AUTH_METHOD_KEY = "auth_method";
        private const string USER_ID_KEY = "firebase_user_id";
        private const string USER_EMAIL_KEY = "firebase_user_email";
        private const string USER_TOKEN_KEY = "firebase_user_token";
        private const string USER_DISPLAY_NAME_KEY = "firebase_user_display_name";

        public MauiFirebaseAuthService(FirebaseAuthClient firebaseAuth)
        {
            _firebaseAuth = firebaseAuth ?? throw new ArgumentNullException(nameof(firebaseAuth));
            _preferences = Preferences.Default;
            LoadUserFromPreferences();
        }

        private void LoadUserFromPreferences()
        {
            try
            {
                // Clear existing user data first
                _currentUser = null;

                var authMethod = _preferences.Get(AUTH_METHOD_KEY, string.Empty);
                var userId = _preferences.Get(USER_ID_KEY, string.Empty);
                var userEmail = _preferences.Get(USER_EMAIL_KEY, string.Empty);
                var userToken = _preferences.Get(USER_TOKEN_KEY, string.Empty);
                var displayName = _preferences.Get(USER_DISPLAY_NAME_KEY, string.Empty);
                var photoUrl = _preferences.Get("USER_PHOTO_URL_KEY", string.Empty);

                if (!string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(authMethod))
                {
                    _currentUser = new FirebaseSignInResponse
                    {
                        LocalId = userId,
                        Email = userEmail,
                        IdToken = userToken,
                        DisplayName = displayName,
                        PhotoUrl = photoUrl
                    };
                    Console.WriteLine($"Usuario cargado de preferencias: {userId} con método: {authMethod}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar usuario de preferencias: {ex.Message}");
                ClearUserData();
            }
        }

        private void SaveUserToPreferences(FirebaseSignInResponse user, string authMethod)
        {
            try
            {
                _preferences.Set(AUTH_METHOD_KEY, authMethod);
                _preferences.Set(USER_ID_KEY, user.LocalId);
                _preferences.Set(USER_EMAIL_KEY, user.Email);
                _preferences.Set(USER_TOKEN_KEY, user.IdToken);
                _preferences.Set(USER_DISPLAY_NAME_KEY, user.DisplayName);
                _preferences.Set("USER_PHOTO_URL_KEY", user.PhotoUrl);
                Console.WriteLine($"Usuario guardado en preferencias: {user.LocalId} con método: {authMethod}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar usuario en preferencias: {ex.Message}");
            }
        }

        private void ClearUserData()
        {
            // Explicitly clear all preferences
            _preferences.Remove(AUTH_METHOD_KEY);
            _preferences.Remove(USER_ID_KEY);
            _preferences.Remove(USER_EMAIL_KEY);
            _preferences.Remove(USER_TOKEN_KEY);
            _preferences.Remove(USER_DISPLAY_NAME_KEY);
            _preferences.Remove("USER_PHOTO_URL_KEY");

            _currentUser = null;

            try
            {
                // Ensure Firebase sign out
                _firebaseAuth.SignOut();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cerrar sesión de Firebase: {ex.Message}");
            }
        }

        public async Task<FirebaseSignInResponse> GetCurrentUser()
        {
            if (_currentUser == null)
            {
                LoadUserFromPreferences();
            }
            return _currentUser;
        }

        public async Task SetCurrentUser(FirebaseSignInResponse user, string authMethod = "email")
        {
            // Primero limpiamos cualquier sesión existente
            ClearUserData();

            // Luego establecemos el nuevo usuario
            _currentUser = user;
            SaveUserToPreferences(user, authMethod);

            Console.WriteLine($"SetCurrentUser - Usuario establecido: {user.LocalId}");
            Console.WriteLine($"SetCurrentUser - Método de autenticación: {authMethod}");

            // Verify the current user after setting
            var currentUser = await GetCurrentUser();
            Console.WriteLine($"Verificación post-SetCurrentUser - LocalId: {currentUser?.LocalId}");
        }

        public bool IsAuthenticated()
        {
            if (_currentUser == null)
            {
                LoadUserFromPreferences();
            }
            return _currentUser != null;
        }

        public string GetCurrentUserId()
        {
            // Force reload of current user
            LoadUserFromPreferences();

            if (_currentUser == null)
            {
                Console.WriteLine("No user loaded from preferences");
                throw new InvalidOperationException("No hay usuario autenticado");
            }

            Console.WriteLine($"Returning user ID: {_currentUser.LocalId}");
            return _currentUser.LocalId;
        }

        public async Task<string> GetCurrentUserToken()
        {
            if (_currentUser == null)
            {
                LoadUserFromPreferences();
                if (_currentUser == null)
                {
                    throw new InvalidOperationException("No hay usuario autenticado");
                }
            }

            // Si el usuario de Firebase está disponible, actualiza el token
            var currentUser = _firebaseAuth.User;
            if (currentUser != null)
            {
                var token = await currentUser.GetIdTokenAsync();
                _currentUser.IdToken = token;
                SaveUserToPreferences(_currentUser, _preferences.Get(AUTH_METHOD_KEY, "email"));
                return token;
            }

            return _currentUser.IdToken;
        }

        public void Logout()
        {
            ClearUserData();
            Console.WriteLine("Usuario deslogueado y preferencias limpiadas");
        }
    }
}