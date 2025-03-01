using BackFoodMacano.DataContext;
using FoodMacanoServices.Models;
using FoodMacanoServices.Models.Orders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class EncarguesController : ControllerBase
{
    private readonly FoodMacanoContext _context;

    public EncarguesController(FoodMacanoContext context)
    {
        _context = context;
    }
    // GET: api/Encargues
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Encargue>>> GetEncargues([FromQuery] int? usuarioId)
    {
        // Filtrar los encargues por usuarioId si se proporciona
        var encarguesQuery = _context.encargues
            .Include(e => e.EncargueDetalles)
            .ThenInclude(ed => ed.Producto)
            .Include(e => e.Usuario)
            .AsQueryable();

        if (usuarioId.HasValue)
        {
            encarguesQuery = encarguesQuery.Where(e => e.UsuarioId == usuarioId.Value);
        }

        var encargues = await encarguesQuery.ToListAsync();
        return encargues;
    }

    // GET: api/Encargues/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Encargue>> GetEncargue(int id)
    {
        var encargue = await _context.encargues
            .Include(e => e.EncargueDetalles)
            .ThenInclude(ed => ed.Producto)
            .Include(e => e.Usuario)
            .FirstOrDefaultAsync(e => e.Id == id);

        if (encargue == null)
        {
            return NotFound();
        }

        return encargue;
    }

    // POST: api/Encargues
    [HttpPost]
    public async Task<ActionResult<Encargue>> PostEncargue([FromBody] Encargue encargue)
    {
        try
        {
            if (!ModelState.IsValid || encargue.EncargueDetalles == null || !encargue.EncargueDetalles.Any())
            {
                return BadRequest("Encargue debe contener al menos un producto.");
            }

            var usuarioExiste = await _context.usuarios.AnyAsync(u => u.Id == encargue.UsuarioId);
            if (!usuarioExiste)
            {
                return BadRequest("El usuario especificado no existe.");
            }

            // Crear un nuevo encargue
            var nuevoEncargue = new Encargue
            {
                UsuarioId = encargue.UsuarioId,
                FechaEncargue = DateTime.UtcNow,
                NumeroEncargue = await _context.encargues.CountAsync() + 1
            };

            _context.encargues.Add(nuevoEncargue);
            await _context.SaveChangesAsync();

            // Agregar los productos al EncargueDetalle
            foreach (var detalle in encargue.EncargueDetalles)
            {
                var productoExiste = await _context.productos.AnyAsync(p => p.Id == detalle.ProductoId);
                if (!productoExiste)
                    return BadRequest($"El producto con ID {detalle.ProductoId} no existe.");

                detalle.EncargueId = nuevoEncargue.Id;
                _context.encargueDetalles.Add(detalle);
            }

            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEncargue), new { id = nuevoEncargue.Id }, nuevoEncargue);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al crear encargue: {ex.Message}");
            return StatusCode(500, "Error interno al procesar el encargue.");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutEncargue(int id, Encargue encargue)
    {
        if (id != encargue.Id)
        {
            return BadRequest("El ID del encargue no coincide.");
        }

        var existingEncargue = await _context.encargues
            .Include(e => e.EncargueDetalles)
            .FirstOrDefaultAsync(e => e.Id == id);

        if (existingEncargue == null)
        {
            return NotFound("Encargue no encontrado.");
        }

        // Actualizar los datos del encargue
        existingEncargue.UsuarioId = encargue.UsuarioId;
        existingEncargue.FechaEncargue = encargue.FechaEncargue;

        // Actualizar detalles sin eliminarlos
        foreach (var detalle in encargue.EncargueDetalles)
        {
            var detalleExistente = existingEncargue.EncargueDetalles
                .FirstOrDefault(d => d.Id == detalle.Id);

            if (detalleExistente != null)
            {
                // Actualizar los datos del detalle existente
                detalleExistente.Cantidad = detalle.Cantidad;
                detalleExistente.ProductoId = detalle.ProductoId;
            }
            else
            {
                // Agregar nuevos detalles si no existen
                existingEncargue.EncargueDetalles.Add(new EncargueDetalle
                {
                    EncargueId = existingEncargue.Id,
                    ProductoId = detalle.ProductoId,
                    Cantidad = detalle.Cantidad
                });
            }
        }

        try
        {
            await _context.SaveChangesAsync();
            return NoContent();
        }
        catch (DbUpdateConcurrencyException)
        {
            return StatusCode(500, "Error al actualizar el encargue.");
        }
    }

    // DELETE: api/Encargues/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEncargue(int id)
    {
        var encargue = await _context.encargues.Include(e => e.EncargueDetalles).FirstOrDefaultAsync(e => e.Id == id);
        if (encargue == null)
        {
            return NotFound();
        }

        _context.encargueDetalles.RemoveRange(encargue.EncargueDetalles);
        _context.encargues.Remove(encargue);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool EncargueExists(int id)
    {
        return _context.encargues.Any(e => e.Id == id);
    }
}
