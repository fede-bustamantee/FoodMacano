using FoodMacanoDesktop.Views.Login;
using FoodMacanoDesktop.Views.Menu;
using FoodMacanoDesktop.Views.Productos;

namespace FoodMacanoDesktop
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Create and show login form
            var loginForm = new IniciarSesionView();
            Application.Run(loginForm);

            // Only proceed to main menu if login was successful
            if (loginForm.loginSuccessfull)
            {
                Application.Run(new MenuPrincipalView());
            }
        }
    }
}