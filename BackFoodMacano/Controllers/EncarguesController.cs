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
            .Include(e => e.Producto)
            .Include(e => e.Usuario)
            .ToListAsync();
    }

    // GET: api/Encargues/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Encargue>> GetEncargue(int id)
    {
        var encargue = await _context.encargues
            .Include(e => e.Producto)
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
    public async Task<ActionResult<Encargue>> PostEncargue(Encargue encargue)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Limpiar propiedades relacionadas para evitar conflictos
            encargue.Producto = null;
            encargue.Usuario = null;

            var productoExiste = await _context.productos.AnyAsync(p => p.Id == encargue.ProductoId);
            var usuarioExiste = await _context.usuarios.AnyAsync(u => u.Id == encargue.UsuarioId);

            if (!productoExiste || !usuarioExiste)
            {
                var errors = new Dictionary<string, string[]>();

                if (!productoExiste)
                    errors.Add("Producto", new[] { "El producto especificado no existe." });

                if (!usuarioExiste)
                    errors.Add("Usuario", new[] { "El usuario especificado no existe." });

                return BadRequest(new { errors });
            }

            if (encargue.FechaEncargue == default)
            {
                encargue.FechaEncargue = DateTime.UtcNow;
            }

            _context.encargues.Add(encargue);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEncargue), new { id = encargue.Id }, encargue);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al crear encargue: {ex.Message}");
            return StatusCode(500, new { message = "Error interno al procesar el encargue.", error = ex.Message });
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

        encargue.Producto = null;
        encargue.Usuario = null;

        _context.Entry(encargue).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EncargueExists(id))
            {
                return NotFound();
            }
            throw;
        }

        return NoContent();
    }

    // DELETE: api/Encargues/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEncargue(int id)
    {
        var encargue = await _context.encargues.FindAsync(id);
        if (encargue == null)
        {
            return NotFound();
        }

        _context.encargues.Remove(encargue);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool EncargueExists(int id)
    {
        return _context.encargues.Any(e => e.Id == id);
    }
}
