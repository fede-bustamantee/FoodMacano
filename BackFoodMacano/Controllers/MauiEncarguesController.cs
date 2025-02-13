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
            .Include(e => e.Detalles) // Incluir detalles del encargue
            .ThenInclude(d => d.Producto) // Incluir productos en los detalles
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
            .Select(e => new MauiEncargue
            {
                Id = e.Id,
                FechaEncargue = e.FechaEncargue,
                Total = e.Total,
                UserId = e.UserId,
                Detalles = e.Detalles.Select(d => new MauiEncargueDetalle
                {
                    Id = d.Id,
                    EncargueId = d.EncargueId,
                    ProductoId = d.ProductoId,
                    NombreProducto = d.NombreProducto,
                    PrecioUnitario = d.PrecioUnitario,
                    Cantidad = d.Cantidad,
                    Producto = _context.productos.FirstOrDefault(p => p.Id == d.ProductoId)
                }).ToList()
            })
            .OrderByDescending(e => e.FechaEncargue)
            .ToListAsync();

        return Ok(encargues);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MauiEncargue>> GetMauiEncargue(int id)
    {
        var mauiEncargue = await _context.mauiEncargue
            .Include(e => e.Detalles)
            .Select(e => new MauiEncargue
            {
                Id = e.Id,
                FechaEncargue = e.FechaEncargue,
                Total = e.Total,
                UserId = e.UserId,
                Detalles = e.Detalles.Select(d => new MauiEncargueDetalle
                {
                    Id = d.Id,
                    EncargueId = d.EncargueId,
                    ProductoId = d.ProductoId,
                    NombreProducto = d.NombreProducto,
                    PrecioUnitario = d.PrecioUnitario,
                    Cantidad = d.Cantidad,
                    Producto = _context.productos.FirstOrDefault(p => p.Id == d.ProductoId)
                }).ToList()
            })
            .FirstOrDefaultAsync(e => e.Id == id);

        if (mauiEncargue == null)
        {
            return NotFound();
        }

        return mauiEncargue;
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
            // Verificar y asignar datos de productos en los detalles
            foreach (var detalle in mauiEncargue.Detalles)
            {
                var producto = await _context.productos.FindAsync(detalle.ProductoId);
                if (producto == null)
                {
                    return BadRequest($"Producto no encontrado: {detalle.ProductoId}");
                }

                // Asegurar que cada detalle está vinculado con el encargue
                detalle.Encargue = mauiEncargue;
                detalle.EncargueId = mauiEncargue.Id; // EF Core lo actualizará automáticamente
                detalle.NombreProducto = producto.Nombre;
                detalle.PrecioUnitario = producto.Precio;
            }

            _context.mauiEncargue.Add(mauiEncargue);
            await _context.SaveChangesAsync(); // EF Core maneja la transacción automáticamente

            return CreatedAtAction(nameof(GetMauiEncargue), new { id = mauiEncargue.Id }, mauiEncargue);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error en PostMauiEncargue: {ex}");
            return StatusCode(500, $"Error interno del servidor: {ex.Message}");
        }
    }
    // DELETE: api/MauiEncargues/5
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