using Firebase.Auth.Providers;
using Firebase.Auth;
using FoodMacanoApp.Views.Carrito;
using FoodMacanoApp.Views.Inicio;
using FoodMacanoApp.Views.Login;
using Microsoft.Extensions.Logging;
using FoodMacanoServices.Interfaces;
using FoodMacanoServices.Models;
using FoodMacanoServices.Services;

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
            builder.Services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig()
            {
                ApiKey = Properties.Resources.ApiKeyFirebase,
                AuthDomain = Properties.Resources.AuthDomainFirebase,
                Providers = new Firebase.Auth.Providers.FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
            }));

#if DEBUG
            builder.Logging.AddDebug();

#endif
            builder.Services.AddSingleton<MauiCarritoService>();
            builder.Services.AddSingleton<IGenericService<Categoria>, GenericService<Categoria>>();
            builder.Services.AddSingleton<IGenericService<Producto>, ProductoService>();
            builder.Services.AddSingleton<ProductoService>();

            // Configura la URL base de la API
            var urlApi = Properties.Resources.UrlApi;
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(urlApi) });
            builder.Services.AddTransient<CarritoView>();
            builder.Services.AddTransient<InicioView>();
            builder.Services.AddTransient<LoginView>();
            builder.Services.AddTransient<InicioSesionView>();
            builder.Services.AddTransient<RegisterView>();

            return builder.Build();
        }
    }
}

