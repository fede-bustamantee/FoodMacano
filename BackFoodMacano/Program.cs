using BackFoodMacano.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

string cadenaConexion = configuration.GetConnectionString("mysqlremoto");

// Add services to the container.
builder.Services.AddControllers();

// Configuración del DBContext con MySQL
builder.Services.AddDbContext<FoodMacanoContext>(options =>
    options.UseMySql(cadenaConexion,
        ServerVersion.AutoDetect(cadenaConexion),
        options => options.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: System.TimeSpan.FromSeconds(30),
            errorNumbersToAdd: null)
    ));

// Configuración del serializador JSON para manejar referencias cíclicas
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

// Configuración de CORS con orígenes específicos permitidos
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", builder =>
        builder.WithOrigins("https://tusitio.com", "http://localhost:5000") // Cambia los orígenes según tus necesidades
               .AllowAnyHeader()
               .AllowAnyMethod());
});

var app = builder.Build();

// Middleware para añadir encabezados de seguridad
app.Use(async (context, next) =>
{
    context.Response.Headers.Add("Cross-Origin-Opener-Policy", "same-origin");
    context.Response.Headers.Add("Cross-Origin-Embedder-Policy", "require-corp");
    await next();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
