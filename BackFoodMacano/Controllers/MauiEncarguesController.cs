using BackFoodMacano.DataContext;
using FoodMacanoServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class MauiEncarguesController : ControllerBase
{
    private readonly FoodMacanoContext _context;

    public MauiEncarguesController(FoodMacanoContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MauiEncargue>>> GetMauiEncargues()
    {
        var encargues = await _context.mauiEncargue
            .Include(e => e.Detalles)
                .ThenInclude(d => d.Producto) // Asegurar que se incluye el producto
            .OrderByDescending(e => e.FechaEncargue)
            .ToListAsync();

        return Ok(encargues);
    }

    [HttpGet("user/{userId}")]
    public async Task<ActionResult<IEnumerable<MauiEncargue>>> GetEncarguesByUser(string userId)
    {
        if (string.IsNullOrEmpty(userId))
        {
            return BadRequest("User ID is required");
        }

        var encargues = await _context.mauiEncargue
            .Where(e => e.UserId == userId)
            .Include(e => e.Detalles)
                .ThenInclude(d => d.Producto) // Incluir el producto en los detalles
            .OrderByDescending(e => e.FechaEncargue)
            .ToListAsync();

        return Ok(encargues);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MauiEncargue>> GetMauiEncargue(int id)
    {
        var mauiEncargue = await _context.mauiEncargue
            .Include(e => e.Detalles)
                .ThenInclude(d => d.Producto) // Asegurar que se carga el producto
            .FirstOrDefaultAsync(e => e.Id == id);

        if (mauiEncargue == null)
        {
            return NotFound();
        }

        return Ok(mauiEncargue);
    }

    [HttpPost]
    public async Task<ActionResult<MauiEncargue>> PostMauiEncargue(MauiEncargue mauiEncargue)
    {
        if (mauiEncargue == null || string.IsNullOrEmpty(mauiEncargue.UserId))
        {
            return BadRequest("Datos inválidos.");
        }

        if (mauiEncargue.Detalles == null || !mauiEncargue.Detalles.Any())
        {
            return BadRequest("El encargue debe incluir al menos un detalle.");
        }

        try
        {
            // Asignar correctamente los datos de los productos
            foreach (var detalle in mauiEncargue.Detalles)
            {
                var producto = await _context.productos.FindAsync(detalle.ProductoId);
                if (producto == null)
                {
                    return BadRequest($"Producto no encontrado: {detalle.ProductoId}");
                }

                detalle.NombreProducto = producto.Nombre;
                detalle.PrecioUnitario = producto.Precio;
            }

            _context.mauiEncargue.Add(mauiEncargue);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMauiEncargue), new { id = mauiEncargue.Id }, mauiEncargue);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error en PostMauiEncargue: {ex}");
            return StatusCode(500, $"Error interno del servidor: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutMauiEncargue(int id, MauiEncargue mauiEncargue)
    {
        if (id != mauiEncargue.Id)
        {
            return BadRequest();
        }

        var encargueExistente = await _context.mauiEncargue
            .Include(e => e.Detalles)
            .FirstOrDefaultAsync(e => e.Id == id);

        if (encargueExistente == null)
        {
            return NotFound();
        }

        // Actualizar propiedades principales
        encargueExistente.UserDisplayName = mauiEncargue.UserDisplayName;
        encargueExistente.Direccion = mauiEncargue.Direccion;
        encargueExistente.FechaEncargue = mauiEncargue.FechaEncargue;
        encargueExistente.Total = mauiEncargue.Total;

        // Actualizar detalles
        foreach (var detalle in mauiEncargue.Detalles)
        {
            var detalleExistente = encargueExistente.Detalles.FirstOrDefault(d => d.Id == detalle.Id);

            if (detalleExistente != null)
            {
                var producto = await _context.productos.FindAsync(detalle.ProductoId);
                detalleExistente.NombreProducto = producto?.Nombre ?? detalle.NombreProducto; // Asegurar nombre correcto
                detalleExistente.Cantidad = detalle.Cantidad;
                detalleExistente.PrecioUnitario = detalle.PrecioUnitario;
            }
        }

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMauiEncargue(int id)
    {
        var mauiEncargue = await _context.mauiEncargue.FindAsync(id);
        if (mauiEncargue == null)
        {
            return NotFound();
        }

        _context.mauiEncargue.Remove(mauiEncargue);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
