using BackFoodMacano.DataContext;
using FoodMacanoServices.Models;
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
    public async Task<IActionResult> PutEncargue(int id, Encargue encargueActualizado)
    {
        if (id != encargueActualizado.Id)
        {
            return BadRequest("El ID en la URL no coincide con el ID en el objeto.");
        }

        var encargueExistente = await _context.encargues
            .Include(e => e.EncargueDetalles)
            .FirstOrDefaultAsync(e => e.Id == id);

        if (encargueExistente == null)
        {
            return NotFound($"No se encontró ningún encargue con ID {id}.");
        }

        // Solo actualiza los campos específicos que deseas modificar
        // Por ejemplo, si solo quieres actualizar el UsuarioId:
        if (encargueActualizado.UsuarioId != 0)
        {
            // Verifica que el nuevo usuario exista
            var usuarioExiste = await _context.usuarios.AnyAsync(u => u.Id == encargueActualizado.UsuarioId);
            if (!usuarioExiste)
            {
                return BadRequest($"El usuario con ID {encargueActualizado.UsuarioId} no existe.");
            }

            encargueExistente.UsuarioId = encargueActualizado.UsuarioId;
        }

        // Si deseas actualizar los detalles, procede solo si hay detalles para actualizar
        if (encargueActualizado.EncargueDetalles != null && encargueActualizado.EncargueDetalles.Any())
        {
            // Verifica que todos los productos existan
            foreach (var detalle in encargueActualizado.EncargueDetalles)
            {
                var productoExiste = await _context.productos.AnyAsync(p => p.Id == detalle.ProductoId);
                if (!productoExiste)
                {
                    return BadRequest($"El producto con ID {detalle.ProductoId} no existe.");
                }
            }

            // Elimina los detalles actuales
            _context.encargueDetalles.RemoveRange(encargueExistente.EncargueDetalles);

            // Agrega los nuevos detalles
            foreach (var detalle in encargueActualizado.EncargueDetalles)
            {
                _context.encargueDetalles.Add(new EncargueDetalle
                {
                    EncargueId = id,
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
            if (!EncargueExists(id))
            {
                return NotFound();
            }
            throw;
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error interno al actualizar el encargue: {ex.Message}");
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
