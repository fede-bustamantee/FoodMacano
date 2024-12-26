using FoodMacanoServices.Interfaces;
using FoodMacanoServices.Models;
using FoodMacanoServices.Services;
using FoodMacanoWeb;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Configura la URL base de la API
var urlApi = builder.Configuration.GetValue<string>("urlApi");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(urlApi) });

// Registra el servicio
builder.Services.AddScoped<IGenericService<Producto>, GenericService<Producto>>();
builder.Services.AddScoped<IGenericService<DescripcionProducto>, GenericService<DescripcionProducto>>();
builder.Services.AddScoped<IGenericService<Categoria>, GenericService<Categoria>>();
builder.Services.AddScoped<IGenericService<Negocio>, GenericService<Negocio>>();
builder.Services.AddScoped<IGenericService<CarritoCompra>, GenericService<CarritoCompra>>();
builder.Services.AddScoped<IGenericService<Encargue>, GenericService<Encargue>>();
builder.Services.AddScoped<IGenericService<Usuario>, GenericService<Usuario>>();
builder.Services.AddScoped<CarritoComprasService>();
builder.Services.AddScoped<EncarguesService>();
builder.Services.AddScoped<IAleatorioService<Producto>, AleatorioService<Producto>>();
builder.Services.AddScoped<FirebaseAuthService>();
builder.Services.AddScoped<UsuarioMappingService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IGenericService<Usuario>, GenericService<Usuario>>();


await builder.Build().RunAsync();
