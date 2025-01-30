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
                Estado = e.Estado,
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
                Estado = e.Estado,
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
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // Verificar y cargar datos de productos
                foreach (var detalle in mauiEncargue.Detalles)
                {
                    var producto = await _context.productos.FindAsync(detalle.ProductoId);
                    if (producto == null)
                    {
                        throw new InvalidOperationException($"Producto no encontrado: {detalle.ProductoId}");
                    }
                    detalle.Producto = producto;
                    detalle.NombreProducto = producto.Nombre;
                    detalle.PrecioUnitario = producto.Precio;
                }

                _context.mauiEncargue.Add(mauiEncargue);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                // Cargar el encargue completo para la respuesta
                var encargueCompleto = await _context.mauiEncargue
                    .Include(e => e.Detalles)
                    .Select(e => new MauiEncargue
                    {
                        Id = e.Id,
                        FechaEncargue = e.FechaEncargue,
                        Estado = e.Estado,
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
                    .FirstOrDefaultAsync(e => e.Id == mauiEncargue.Id);

                return CreatedAtAction(nameof(GetMauiEncargue), new { id = mauiEncargue.Id }, encargueCompleto);
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error interno del servidor: {ex.Message}");
        }
    }
}