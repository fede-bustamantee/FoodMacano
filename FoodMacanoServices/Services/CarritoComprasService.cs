using FoodMacanoServices.Interfaces;
using FoodMacanoServices.Models;
using FoodMacanoServices.Services;

public class CarritoService : ICarritoService
{
    private readonly FirebaseAuthService _authService;
    private readonly UsuarioMappingService _usuarioMappingService;
    private readonly IEncargueService _encargueService;

    public CarritoService(
        FirebaseAuthService authService,
        UsuarioMappingService usuarioMappingService,
        IEncargueService encargueService)
    {
        _authService = authService;
        _usuarioMappingService = usuarioMappingService;
        _encargueService = encargueService;
    }

    public async Task<List<CarritoCompra>> GetCartItemsAsync()
    {
        var firebaseId = await _authService.GetUserId();
        return CarritoStore.GetCarrito(firebaseId);
    }

    public async Task AddToCartAsync(Producto producto)
    {
        var firebaseId = await _authService.GetUserId();
        if (string.IsNullOrEmpty(firebaseId))
        {
            throw new InvalidOperationException("Usuario no autenticado");
        }

        var userId = await _usuarioMappingService.GetUsuarioIdFromFirebaseId(firebaseId);
        var carrito = CarritoStore.GetCarrito(firebaseId);
        var existingItem = carrito.FirstOrDefault(i => i.ProductoId == producto.Id);

        if (existingItem != null)
        {
            existingItem.Cantidad++;
        }
        else
        {
            carrito.Add(new CarritoCompra
            {
                Id = CarritoStore.GetNextId(),
                ProductoId = producto.Id,
                Cantidad = 1,
                UsuarioId = userId,
                Producto = producto
            });
        }
    }

    public async Task RemoveFromCartAsync(int itemId)
    {
        var firebaseId = await _authService.GetUserId();
        var carrito = CarritoStore.GetCarrito(firebaseId);
        var item = carrito.FirstOrDefault(i => i.Id == itemId);
        if (item != null)
        {
            carrito.Remove(item);
        }
    }

    public async Task CheckoutAsync()
{
    try
    {
        var firebaseId = await _authService.GetUserId();
        if (string.IsNullOrEmpty(firebaseId))
            throw new InvalidOperationException("Usuario no autenticado.");

        var carrito = CarritoStore.GetCarrito(firebaseId);
        if (!carrito.Any())
            throw new InvalidOperationException("El carrito está vacío. No se puede realizar el checkout.");

        var userId = await _usuarioMappingService.GetUsuarioIdFromFirebaseId(firebaseId);

        // Crear un solo encargue con todos los productos del carrito
        var nuevoEncargue = new Encargue
        {
            UsuarioId = userId,
            FechaEncargue = DateTime.UtcNow,
            NumeroEncargue = await _encargueService.GetNextEncargueNumberAsync(),
            EncargueDetalles = carrito.Select(item => new EncargueDetalle
            {
                ProductoId = item.ProductoId,
                Cantidad = item.Cantidad
            }).ToList()
        };

        await _encargueService.AddEncargueAsync(nuevoEncargue);

        // Vaciar el carrito después de realizar el checkout
        CarritoStore.ClearCarrito(firebaseId);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error en CheckoutAsync: {ex.Message}");
        throw;
    }
}

    public async Task<int> GetCartItemCountAsync()
    {
        var firebaseId = await _authService.GetUserId();
        var carrito = CarritoStore.GetCarrito(firebaseId);
        return carrito.Sum(item => item.Cantidad);
    }

    public async Task<int> GetUniqueItemCountAsync()
    {
        var firebaseId = await _authService.GetUserId();
        var carrito = CarritoStore.GetCarrito(firebaseId);
        return carrito.Count;
    }
}