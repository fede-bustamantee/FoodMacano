using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth.Providers;
using Firebase.Auth.Repository;
using Firebase.Auth;
using FoodMacanoServices.Interfaces;
using FoodMacanoServices.Services;
using FoodMacanoServices.Models;

namespace FoodMacanoApp.ViewModels
{
    public partial class IniciarSesionViewModel : ObservableObject
    {
        private readonly FirebaseAuthClient _clientAuth;
        public readonly FileUserRepository _userRepository;
        private UserInfo _userInfo;
        private FirebaseCredential _firebaseCredential;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(IniciarSesionCommand))]
        private string email;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(IniciarSesionCommand))]
        private string password;

        public IRelayCommand IniciarSesionCommand { get; }
        public IRelayCommand RegistrarseCommand { get; }

        public IniciarSesionViewModel()
        {
            _clientAuth = new FirebaseAuthClient(new FirebaseAuthConfig()
            {
                ApiKey = Properties.Resources.ApiKeyFirebase,
                AuthDomain = Properties.Resources.AuthDomainFirebase,
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
            });
            _userRepository = new FileUserRepository("FoodMacanoApp");
            ChequearSiHayUsuarioAlmacenado();
            IniciarSesionCommand = new RelayCommand(IniciarSesion);
            RegistrarseCommand = new RelayCommand(Registrarse);
        }

        private async void Registrarse()
        {
            await Shell.Current.GoToAsync("Registrarse");
        }

        private async void ChequearSiHayUsuarioAlmacenado()
        {
            try
            {
                // Check if user exists in repository
                if (_userRepository.UserExists())
                {
                    (_userInfo, _firebaseCredential) = _userRepository.ReadUser();

                    // Verify token validity
                    var token = _firebaseCredential.IdToken;
                    if (string.IsNullOrEmpty(token))
                    {
                        _userRepository.DeleteUser();
                        return;
                    }

                    var authService = Application.Current.Handler.MauiContext.Services.GetService<IAuthService>() as MauiFirebaseAuthService;

                    if (authService != null)
                    {
                        var firebaseResponse = new FirebaseSignInResponse
                        {
                            LocalId = _userInfo.Uid,
                            Email = _userInfo.Email,
                            IdToken = token,
                            DisplayName = _userInfo.DisplayName
                        };

                        await authService.SetCurrentUser(firebaseResponse, "email");

                        var institutoShell = (AppShell)App.Current.MainPage;
                        institutoShell.EnableAppAfterLogin();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al verificar usuario almacenado: {ex.Message}");
                _userRepository.DeleteUser();
            }
        }
        private async void IniciarSesion()
        {
            try
            {
                // Validación de campos vacíos
                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                {
                    await Application.Current.MainPage.DisplayAlert("Advertencia",
                        "Por favor complete todos los campos", "Ok");
                    return;
                }

                var userCredential = await _clientAuth.SignInWithEmailAndPasswordAsync(email, password);

                if (!userCredential.User.Info.IsEmailVerified)
                {
                    await Application.Current.MainPage.DisplayAlert("Inicio de sesión",
                        "Debe verificar su correo electrónico", "Ok");
                    return;
                }

                // Obtener el token y crear FirebaseSignInResponse
                var token = await userCredential.User.GetIdTokenAsync();
                var firebaseResponse = new FirebaseSignInResponse
                {
                    LocalId = userCredential.User.Uid,
                    Email = userCredential.User.Info.Email,
                    IdToken = token,
                    DisplayName = userCredential.User.Info.DisplayName
                };

                // Obtener el servicio de autenticación y guardar el usuario
                var authService = Application.Current.Handler.MauiContext.Services.GetService<IAuthService>()
                    as MauiFirebaseAuthService;
                if (authService != null)
                {
                    await authService.SetCurrentUser(firebaseResponse, "email");
                }

                var appShell = (AppShell)App.Current.MainPage;
                appShell.EnableAppAfterLogin();
            }
            catch (FirebaseAuthException error)
            {
                Console.WriteLine($"Error de autenticación: {error.Message}");
                await Application.Current.MainPage.DisplayAlert("Error de inicio de sesión",
                    "Correo o contraseña incorrectos", "Ok");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error",
                    "Ocurrió un error inesperado al iniciar sesión", "Ok");
            }
        }
    }
}