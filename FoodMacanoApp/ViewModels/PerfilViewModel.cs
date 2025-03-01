using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FoodMacanoServices.Interfaces;
using FoodMacanoServices.Models.FireAuth;

namespace FoodMacanoApp.ViewModels
{
    public partial class PerfilViewModel : ObservableObject
    {
        private readonly IAuthService _authService;

        [ObservableProperty]
        private FirebaseSignInResponse _usuarioActual;

        // Constructor que recibe el servicio de autenticación
        public PerfilViewModel(IAuthService authService)
        {
            _authService = authService;
            CargarInformacionUsuario(); // Carga la información del usuario al instanciar la vista
        }

        // Método asíncrono para obtener la información del usuario autenticado
        private async void CargarInformacionUsuario()
        {
            try
            {
                UsuarioActual = await _authService.GetCurrentUser(); // Obtiene el usuario actual
            }
            catch (Exception ex)
            {
                // Captura errores en la carga de información y los muestra en la consola
                Console.WriteLine($"Error al cargar información de usuario: {ex.Message}");
            }
        }

        // Comando que permite al usuario cerrar sesión
        [RelayCommand]
        public void CerrarSesion()
        {
            _authService.Logout(); // Llama al servicio de autenticación para cerrar sesión
        }
    }
}