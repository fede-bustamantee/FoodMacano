using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FoodMacanoServices.Interfaces;
using FoodMacanoServices.Models;

namespace FoodMacanoApp.ViewModels
{
    public partial class PerfilViewModel : ObservableObject
    {
        private readonly IAuthService _authService;

        [ObservableProperty]
        private FirebaseSignInResponse _usuarioActual;

        public PerfilViewModel(IAuthService authService)
        {
            _authService = authService;
            CargarInformacionUsuario();
        }

        private async void CargarInformacionUsuario()
        {
            try
            {
                UsuarioActual = await _authService.GetCurrentUser();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar información de usuario: {ex.Message}");
            }
        }

        [RelayCommand]
        public void CerrarSesion()
        {
            _authService.Logout();
        }
    }
}