using FoodMacanoApp.ViewModels;
using FoodMacanoApp.Views.Busqueda;
using FoodMacanoApp.Views.Carrito;
using FoodMacanoApp.Views.Encargue;
using FoodMacanoApp.Views.Informacion;
using FoodMacanoApp.Views.Inicio;
using FoodMacanoApp.Views.Login;
using FoodMacanoApp.Views.Negocios;
using FoodMacanoApp.Views.Perfil;
using FoodMacanoServices.Interfaces;

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
            // Se registran las rutas para la navegación dentro de la aplicación
            Routing.RegisterRoute("Registrarse", typeof(RegisterView));
            Routing.RegisterRoute("InicioView", typeof(InicioView));
            Routing.RegisterRoute("CarritoView", typeof(CarritoView));
            Routing.RegisterRoute("EncargueView", typeof(EncargueView));
            Routing.RegisterRoute("InformacionView", typeof(InformacionView));
            Routing.RegisterRoute("NegocioView", typeof(NegociosView));
            Routing.RegisterRoute("PerfilView", typeof(PerfilView));
            Routing.RegisterRoute("LoginView", typeof(LoginView));
            Routing.RegisterRoute("SearchView", typeof(SearchView));
        }

        public async void EnableAppAfterLogin()
        {
            try
            {
                Console.WriteLine("Habilitando la aplicación después del login...");

                if (this.BindingContext is not ShellViewModel viewModel)
                {
                    throw new InvalidOperationException("ShellViewModel es null en EnableAppAfterLogin");
                }

                viewModel.UserIsLogout = false;

                await Shell.Current.GoToAsync($"//{nameof(InicioView)}", true);

                Console.WriteLine("Navegación a InicioView completada");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en EnableAppAfterLogin: {ex.GetType().Name}: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");

                await Shell.Current.DisplayAlert("Error", "No se pudo acceder a la página principal", "OK");

                if (this.BindingContext is ShellViewModel vm)
                {
                    vm.UserIsLogout = true;
                }
            }
        }

        public void DisableAppAfterLogin()
        {
            // Obtiene el servicio de autenticación desde los servicios registrados en la aplicación
            var authService = Application.Current.Handler.MauiContext.Services.GetService<IAuthService>();
            if (authService != null)
            {
                authService.Logout(); // Cierra sesión del usuario
            }

            // Deshabilita el menú lateral (Flyout)
            FlyoutBehavior = FlyoutBehavior.Disabled;

            // Redirige al usuario a la pantalla de inicio de sesión
            Shell.Current.GoToAsync("LoginView");
        }
    }
}