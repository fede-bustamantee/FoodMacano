using FoodMacanoDesktop.Views.Login;
using FoodMacanoDesktop.Views.Menu;

namespace FoodMacanoDesktop
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Crea una instancia del formulario de inicio de sesión (IniciarSesionView).
            var loginForm = new IniciarSesionView();
            // Ejecuta el formulario de inicio de sesión. La ejecución se detiene aquí hasta que el formulario sea cerrado.
            Application.Run(loginForm);

            // Verifica si el inicio de sesión fue exitoso.
            if (loginForm.loginSuccessfull)
            {
                // Si el inicio de sesión fue exitoso, se ejecuta el formulario principal (MenuPrincipalView).
                Application.Run(new MenuPrincipalView());
            }
        }
    }
}
