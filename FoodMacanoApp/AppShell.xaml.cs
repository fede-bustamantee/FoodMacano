using FoodMacanoApp.ViewModels;
using FoodMacanoApp.Views.Carrito;
using FoodMacanoApp.Views.Inicio;
using FoodMacanoApp.Views.Login;

namespace FoodMacanoApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
            BindingContext = new ShellViewModel();
        }
        private void RegisterRoutes()
        {
            Routing.RegisterRoute("Registrarse", typeof(RegisterView));
            Routing.RegisterRoute("InicioView", typeof(InicioView));
            Routing.RegisterRoute("InicioSesionView", typeof(InicioSesionView));
            Routing.RegisterRoute("CarritoView", typeof(CarritoView));

        }

        public async void EnableAppAfterLogin()
        {
            try
            {
                // Primero verificar el BindingContext
                if (this.BindingContext is not ShellViewModel viewModel)
                {
                    await Shell.Current.DisplayAlert("Error", "Error de inicialización de la aplicación", "OK");
                    return;
                }

                // Actualizar el estado antes de navegar
                viewModel.UserIsLogout = false;

                // Asegurarse que la ruta existe
                var route = $"//{nameof(InicioView)}";
                await Shell.Current.GoToAsync(route, true);
            }
            catch (Exception ex)
            {
                // Log del error para debugging
                Console.WriteLine($"Error en EnableAppAfterLogin: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");

                // Mensaje amigable al usuario
                await Shell.Current.DisplayAlert(
                    "Error",
                    "No se pudo acceder a la página principal. Por favor, intente nuevamente.",
                    "OK"
                );

                // Reiniciar el estado si algo falla
                if (this.BindingContext is ShellViewModel vm)
                {
                    vm.UserIsLogout = true;
                }
            }
        }

        public void DisableAppAfterLogin()
        {
            FlyoutBehavior = FlyoutBehavior.Disabled; // Deshabilita el FlyOut
            Shell.Current.GoToAsync("Login"); // Navega a la página de login
        }
    }
}
