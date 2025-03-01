using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth.Providers;
using Firebase.Auth;
using System.Net.Http.Json;
using System.Net.Http.Headers;

namespace FoodMacanoApp.ViewModels
{
    public partial class RegisterViewModel : ObservableObject
    {
        private readonly FirebaseAuthClient _clientAuth;
        private readonly string FirebaseApiKey;
        private readonly string RequestUri;

        public IRelayCommand RegistrarseCommand { get; }

        [ObservableProperty]
        private string nombre;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private string verifyPassword;

        public RegisterViewModel()
        {
            // Se obtiene la clave de API de Firebase desde los recursos de la aplicación
            FirebaseApiKey = Properties.Resources.ApiKeyFirebase;
            // Se construye la URL de solicitud para el envío de correos de verificación
            RequestUri = "https://identitytoolkit.googleapis.com/v1/accounts:sendOobCode?key=" + FirebaseApiKey;
            // Se define el comando de registro
            RegistrarseCommand = new RelayCommand(Registrarse);
            // Se inicializa el cliente de autenticación de Firebase
            _clientAuth = new FirebaseAuthClient(new FirebaseAuthConfig()
            {
                ApiKey = FirebaseApiKey,
                AuthDomain = Properties.Resources.AuthDomainFirebase,
                Providers = new Firebase.Auth.Providers.FirebaseAuthProvider[]
                {
                        new EmailProvider()
                }
            });
        }

        private async void Registrarse()
        {
            // Verificar que todos los campos estén completos
            if (string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(verifyPassword) ||
                string.IsNullOrWhiteSpace(nombre))
            {
                await Application.Current.MainPage.DisplayAlert("Registrarse", "Por favor, complete todos los campos", "Ok");
                return;
            }

            // Verificar que las contraseñas coincidan
            if (password != verifyPassword)
            {
                await Application.Current.MainPage.DisplayAlert("Registrarse", "Las contraseñas ingresadas no coinciden", "Ok");
                return;
            }

            try
            {
                // Crear usuario en Firebase con correo y contraseña
                var user = await _clientAuth.CreateUserWithEmailAndPasswordAsync(email, password, nombre);
                // Enviar correo de verificación
                await SendVerificationEmailAsync(user.User.GetIdTokenAsync().Result);
                // Notificar al usuario sobre la creación de la cuenta
                await Application.Current.MainPage.DisplayAlert("Registrarse", "¡Cuenta creada! Veríficala", "Ok");
                // Redirigir a la vista de inicio de sesión
                await Shell.Current.GoToAsync("LoginView");
            }
            catch (FirebaseAuthException error)
            {
                // Captura errores específicos de autenticación de Firebase
                await Application.Current.MainPage.DisplayAlert("Registrarse", "Ocurrió un problema: " + error.Reason, "Ok");
            }
            catch (Exception ex)
            {
                // Captura errores generales
                await Application.Current.MainPage.DisplayAlert("Registrarse", "Ocurrió un error inesperado: " + ex.Message, "Ok");
            }
        }

        public async Task SendVerificationEmailAsync(string idToken)
        {
            // Método para enviar correo de verificación al usuario
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var content = new StringContent("{\"requestType\":\"VERIFY_EMAIL\",\"idToken\":\"" + idToken + "\"}");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await client.PostAsync(RequestUri, content);
                response.EnsureSuccessStatusCode();
            }
        }
    }
}
