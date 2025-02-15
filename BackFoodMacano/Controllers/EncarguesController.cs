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
    public async Task<ActionResult<IEnumerable<Encargue>>> GetEncargues()
    {
        return await _context.encargues
            .Include(e => e.EncargueDetalles)
            .ThenInclude(ed => ed.Producto)
            .Include(e => e.Usuario)
            .ToListAsync();
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

    // PUT: api/Encargues/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutEncargue(int id, Encargue encargue)
    {
        if (id != encargue.Id)
        {
            return BadRequest();
        }

        var existingEncargue = await _context.encargues.Include(e => e.EncargueDetalles).FirstOrDefaultAsync(e => e.Id == id);
        if (existingEncargue == null)
        {
            return NotFound();
        }

        existingEncargue.UsuarioId = encargue.UsuarioId;
        existingEncargue.FechaEncargue = DateTime.UtcNow;

        // Actualizar productos
        _context.encargueDetalles.RemoveRange(existingEncargue.EncargueDetalles);
        existingEncargue.EncargueDetalles = encargue.EncargueDetalles;

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
