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
            FirebaseApiKey = Properties.Resources.ApiKeyFirebase;
            RequestUri = "https://identitytoolkit.googleapis.com/v1/accounts:sendOobCode?key=" + FirebaseApiKey;
            RegistrarseCommand = new RelayCommand(Registrarse);
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
            if (password == verifyPassword)
            {
                try
                {
                    var user = await _clientAuth.CreateUserWithEmailAndPasswordAsync(email, password, nombre);
                    await SendVerificationEmailAsync(user.User.GetIdTokenAsync().Result);
                    await Application.Current.MainPage.DisplayAlert("Registrarse", "Cuenta creada!", "Ok");
                }
                catch (FirebaseAuthException error) // Use alias here 
                {
                    await Application.Current.MainPage.DisplayAlert("Registrarse", "Ocurrió un problema:" + error.Reason, "Ok");

                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Registrarse", "Las contraseñas ingresadas no coinciden", "Ok");
            }
        }

        public async Task SendVerificationEmailAsync(string idToken)
        {
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
