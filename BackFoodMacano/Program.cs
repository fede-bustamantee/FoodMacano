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

// Configuraci�n del DbContext
builder.Services.AddDbContext<FoodMacanoContext>(options =>
    options.UseMySql(cadenaConexion,
        ServerVersion.AutoDetect(cadenaConexion),
        options => options.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: System.TimeSpan.FromSeconds(30),
            errorNumbersToAdd: null
        )
    ));

// Configuraci�n del serializador JSON para manejar referencias c�clicas
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

// Configuraci�n de Endpoints y Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuraci�n de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
        builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();

// Middleware para agregar encabezados de seguridad
app.Use(async (context, next) =>
{
    context.Response.Headers.Add("Cross-Origin-Opener-Policy", "same-origin");
    context.Response.Headers.Add("Cross-Origin-Embedder-Policy", "require-corp");
    await next();
});

// Configuraci�n del pipeline de la aplicaci�n
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();