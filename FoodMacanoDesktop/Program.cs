using FoodMacanoDesktop.Views.Login;
using FoodMacanoDesktop.Views.Menu;
using FoodMacanoDesktop.Views.Productos;

namespace FoodMacanoDesktop
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            Application.Run(new MenuPrincipalView());

        }
    }
}