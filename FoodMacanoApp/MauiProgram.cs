using FoodMacanoApp.Views.Carrito;
using FoodMacanoApp.Views.Inicio;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;

namespace FoodMacanoApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("fa-solid-900.ttf", "FontAwesomeSolid");
                    fonts.AddFont("fa-regular-400.ttf", "FontAwesomeRegular");
                    fonts.AddFont("fa-brands-400.ttf", "FontAwesomeBrands");
                    fonts.AddFont("Afacad", "Afacad");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            // Configura la URL base de la API
            var urlApi = Properties.Resources.UrlApi;
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(urlApi) });
            builder.Services.AddTransient<CarritoView>();
            builder.Services.AddTransient<Inicio>();

            return builder.Build();
        }
    }
}

