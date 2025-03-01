using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth.Providers;
using Firebase.Auth.Repository;
using Firebase.Auth;
using FoodMacanoServices.Interfaces;
using FoodMacanoServices.Models;
using FoodMacanoServices.Services.FireAuth;
using FoodMacanoServices.Models.FireAuth;

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
            // Inicializar el cliente de autenticación con Firebase
            _clientAuth = new FirebaseAuthClient(new FirebaseAuthConfig()
            {
                ApiKey = Properties.Resources.ApiKeyFirebase,
                AuthDomain = Properties.Resources.AuthDomainFirebase,
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider() // Usando el proveedor de autenticación con correo electrónico
                }
            });
            _userRepository = new FileUserRepository("FoodMacanoApp"); // Repositorio para gestionar el almacenamiento del usuario
            ChequearSiHayUsuarioAlmacenado(); // Verifica si hay un usuario previamente almacenado
            IniciarSesionCommand = new RelayCommand(IniciarSesion); // Comando para iniciar sesión
            RegistrarseCommand = new RelayCommand(Registrarse); // Comando para registrarse
        }

        // Método para navegar a la pantalla de registro
        private async void Registrarse()
        {
            await Shell.Current.GoToAsync("Registrarse");
        }

        // Método para verificar si hay un usuario almacenado en el dispositivo
        private async void ChequearSiHayUsuarioAlmacenado()
        {
            try
            {
                // Verificar si existe un usuario en el repositorio
                if (_userRepository.UserExists())
                {
                    // Leer la información del usuario almacenado
                    (_userInfo, _firebaseCredential) = _userRepository.ReadUser();

                    // Verificar si el token es válido
                    var token = _firebaseCredential.IdToken;
                    if (string.IsNullOrEmpty(token))
                    {
                        _userRepository.DeleteUser(); // Eliminar el usuario si el token es inválido
                        return;
                    }

                    // Obtener el servicio de autenticación y autenticar al usuario
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

                        // Establecer el usuario actual en el servicio de autenticación
                        await authService.SetCurrentUser(firebaseResponse, "email");

                        // Activar la aplicación después de iniciar sesión
                        var institutoShell = (AppShell)App.Current.MainPage;
                        institutoShell.EnableAppAfterLogin();
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores en caso de problemas al verificar el usuario
                Console.WriteLine($"Error al verificar usuario almacenado: {ex.Message}");
                _userRepository.DeleteUser(); // Eliminar usuario en caso de error
            }
        }

        // Método para manejar el inicio de sesión
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

                // Intentar iniciar sesión con correo y contraseña
                var userCredential = await _clientAuth.SignInWithEmailAndPasswordAsync(email, password);

                // Verificar si el correo ha sido verificado
                if (!userCredential.User.Info.IsEmailVerified)
                {
                    await Application.Current.MainPage.DisplayAlert("Inicio de sesión",
                        "Debe verificar su correo electrónico", "Ok");
                    return;
                }

                // Obtener el token de autenticación
                var token = await userCredential.User.GetIdTokenAsync();
                var firebaseResponse = new FirebaseSignInResponse
                {
                    LocalId = userCredential.User.Uid,
                    Email = userCredential.User.Info.Email,
                    IdToken = token,
                    DisplayName = userCredential.User.Info.DisplayName
                };

                // Obtener el servicio de autenticación y almacenar la información del usuario
                var authService = Application.Current.Handler.MauiContext.Services.GetService<IAuthService>()
                    as MauiFirebaseAuthService;
                if (authService != null)
                {
                    await authService.SetCurrentUser(firebaseResponse, "email");
                }

                // Activar la aplicación después de iniciar sesión
                var appShell = (AppShell)App.Current.MainPage;
                appShell.EnableAppAfterLogin();
            }
            catch (FirebaseAuthException error)
            {
                // Manejo de errores específicos de Firebase
                Console.WriteLine($"Error de autenticación: {error.Message}");
                await Application.Current.MainPage.DisplayAlert("Error de inicio de sesión",
                    "Correo o contraseña incorrectos", "Ok");
            }
            catch (Exception ex)
            {
                // Manejo de errores generales
                Console.WriteLine($"Error inesperado: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error",
                    "Ocurrió un error inesperado al iniciar sesión", "Ok");
            }
        }
    }
}