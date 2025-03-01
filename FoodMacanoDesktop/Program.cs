using FoodMacanoDesktop.Views.Login;
using FoodMacanoDesktop.Views.Menu;

namespace FoodMacanoDesktop
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Crea una instancia del formulario de inicio de sesi�n (IniciarSesionView).
            var loginForm = new IniciarSesionView();
            // Ejecuta el formulario de inicio de sesi�n. La ejecuci�n se detiene aqu� hasta que el formulario sea cerrado.
            Application.Run(loginForm);

            // Verifica si el inicio de sesi�n fue exitoso.
            if (loginForm.loginSuccessfull)
            {
                // Si el inicio de sesi�n fue exitoso, se ejecuta el formulario principal (MenuPrincipalView).
                Application.Run(new MenuPrincipalView());
            }
        }
    }
}
