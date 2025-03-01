using Firebase.Auth;
using Firebase.Auth.Repository;
using FoodMacanoServices.Interfaces;
using FoodMacanoServices.Models.FireAuth;
using Microsoft.Maui.Storage;

namespace FoodMacanoServices.Services.FireAuth
{
    public class MauiFirebaseAuthService : IAuthService
    {
        private readonly FirebaseAuthClient _firebaseAuth;
        private FirebaseSignInResponse _currentUser;
        private readonly IPreferences _preferences; // Interfaz para manejar preferencias (almacenamiento local)

        // Constantes para las claves utilizadas al guardar la información del usuario en preferencias
        private const string AUTH_METHOD_KEY = "auth_method";
        private const string USER_ID_KEY = "firebase_user_id";
        private const string USER_EMAIL_KEY = "firebase_user_email";
        private const string USER_TOKEN_KEY = "firebase_user_token";
        private const string USER_DISPLAY_NAME_KEY = "firebase_user_display_name";

        // Constructor que recibe el cliente de autenticación de Firebase
        public MauiFirebaseAuthService(FirebaseAuthClient firebaseAuth)
        {
            _firebaseAuth = firebaseAuth ?? throw new ArgumentNullException(nameof(firebaseAuth));
            _preferences = Preferences.Default; // Accede al almacenamiento de preferencias predeterminado
            LoadUserFromPreferences();
        }

        // Método para cargar la información del usuario desde las preferencias locales
        private void LoadUserFromPreferences()
        {
            try
            {
                // Limpiar cualquier dato de usuario previamente cargado
                _currentUser = null;

                // Cargar los datos del usuario desde las preferencias
                var authMethod = _preferences.Get(AUTH_METHOD_KEY, string.Empty);
                var userId = _preferences.Get(USER_ID_KEY, string.Empty);
                var userEmail = _preferences.Get(USER_EMAIL_KEY, string.Empty);
                var userToken = _preferences.Get(USER_TOKEN_KEY, string.Empty);
                var displayName = _preferences.Get(USER_DISPLAY_NAME_KEY, string.Empty);
                var photoUrl = _preferences.Get("USER_PHOTO_URL_KEY", string.Empty);

                // Si hay un ID de usuario y un método de autenticación, se crea un objeto con los datos del usuario
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

        // Método para guardar la información del usuario en las preferencias locales
        private void SaveUserToPreferences(FirebaseSignInResponse user, string authMethod)
        {
            try
            {
                // Guardar la información del usuario en las preferencias
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

        // Método para limpiar los datos del usuario de las preferencias y cerrar sesión de Firebase
        private void ClearUserData()
        {
            // Eliminar las preferencias del usuario
            _preferences.Remove(AUTH_METHOD_KEY);
            _preferences.Remove(USER_ID_KEY);
            _preferences.Remove(USER_EMAIL_KEY);
            _preferences.Remove(USER_TOKEN_KEY);
            _preferences.Remove(USER_DISPLAY_NAME_KEY);
            _preferences.Remove("USER_PHOTO_URL_KEY");

            _currentUser = null; // Limpiar el usuario actual

            try
            {
                // Asegurarse de cerrar sesión en Firebase
                _firebaseAuth.SignOut();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cerrar sesión de Firebase: {ex.Message}");
            }
        }

        // Método para obtener el usuario actual, cargándolo de las preferencias si es necesario
        public async Task<FirebaseSignInResponse> GetCurrentUser()
        {
            if (_currentUser == null)
            {
                LoadUserFromPreferences(); // Si no hay usuario cargado, cargarlo desde las preferencias
            }
            return _currentUser;
        }

        // Método para establecer el usuario actual, limpiando cualquier sesión anterior y guardando el nuevo usuario
        public async Task SetCurrentUser(FirebaseSignInResponse user, string authMethod = "email")
        {
            // Primero, limpiamos cualquier sesión anterior
            ClearUserData();

            // Luego, se establece el nuevo usuario
            _currentUser = user;
            SaveUserToPreferences(user, authMethod);

            Console.WriteLine($"SetCurrentUser - Usuario establecido: {user.LocalId}");
            Console.WriteLine($"SetCurrentUser - Método de autenticación: {authMethod}");

            // Verificar el usuario actual después de establecerlo
            var currentUser = await GetCurrentUser();
            Console.WriteLine($"Verificación post-SetCurrentUser - LocalId: {currentUser?.LocalId}");
        }

        // Método para verificar si el usuario está autenticado (existe un usuario cargado)
        public bool IsAuthenticated()
        {
            if (_currentUser == null)
            {
                LoadUserFromPreferences(); // Cargar el usuario desde las preferencias si no está cargado
            }
            return _currentUser != null; // Retorna true si el usuario está autenticado
        }

        // Método para obtener el ID del usuario actual, asegurándose de cargarlo si no está cargado
        public string GetCurrentUserId()
        {
            // Forzar la recarga del usuario actual
            LoadUserFromPreferences();

            if (_currentUser == null)
            {
                Console.WriteLine("No user loaded from preferences");
                throw new InvalidOperationException("No hay usuario autenticado"); // Si no hay usuario, lanzar excepción
            }

            Console.WriteLine($"Returning user ID: {_currentUser.LocalId}");
            return _currentUser.LocalId; // Retorna el ID del usuario actual
        }

        // Método para obtener el token del usuario actual, actualizándolo si es necesario
        public async Task<string> GetCurrentUserToken()
        {
            if (_currentUser == null)
            {
                LoadUserFromPreferences(); // Cargar el usuario desde las preferencias si no está cargado
                if (_currentUser == null)
                {
                    throw new InvalidOperationException("No hay usuario autenticado"); // Si no hay usuario, lanzar excepción
                }
            }

            // Si el usuario de Firebase está disponible, actualizamos el token
            var currentUser = _firebaseAuth.User;
            if (currentUser != null)
            {
                var token = await currentUser.GetIdTokenAsync(); // Obtener el token del usuario de Firebase
                _currentUser.IdToken = token; // Actualizar el token en el objeto del usuario
                SaveUserToPreferences(_currentUser, _preferences.Get(AUTH_METHOD_KEY, "email")); // Guardar el token actualizado
                return token; // Retornar el token
            }

            return _currentUser.IdToken; // Si ya se tiene el token, retornar el que está almacenado
        }

        // Método para cerrar sesión y limpiar los datos de usuario
        public void Logout()
        {
            ClearUserData(); // Limpiar los datos de usuario
            Console.WriteLine("Usuario deslogueado y preferencias limpiadas");
        }
    }
}