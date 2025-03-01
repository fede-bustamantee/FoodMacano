using System.Diagnostics;

namespace FoodMacanoDesktop.Util
{
    // Clase estática para mostrar y ocultar una ventana de actividad
    public static class ShowInActivity
    {
        static Views.ShowInActivity.ActivityView showInActivityView;

        static Stopwatch watch;

        public static void Show(string message)
        {
            // Patrón Singleton: se crea la instancia solo si no existe
            if (showInActivityView == null)
                showInActivityView = new Views.ShowInActivity.ActivityView();

            // Se asigna el mensaje a la ventana de actividad
            showInActivityView.Message = message;

            // Si la ventana no está visible, se muestra y se inicia el cronómetro
            if (!showInActivityView.Visible)
            {
                watch = System.Diagnostics.Stopwatch.StartNew(); // Iniciar el cronómetro
                showInActivityView.Show(); // Mostrar la ventana de actividad
            }
        }
        public static void Hide()
        {
            // Se oculta la ventana de actividad
            showInActivityView.Hide();

            // Se detiene el cronómetro
            watch.Stop();

            // Se obtiene el tiempo transcurrido en milisegundos
            var elapsedMs = watch.ElapsedMilliseconds;

            // Se imprime el tiempo de ejecución en la consola de depuración
            Debug.Print($"Tiempo de ejecución: {elapsedMs} ms");
        }
    }
}