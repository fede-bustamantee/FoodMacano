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
    public async Task<ActionResult<Encargue>> PostEncargue([FromBody] Encargue encargue)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Verificar existencia de Producto y Usuario
            var productoExiste = await _context.productos.AnyAsync(p => p.Id == encargue.ProductoId);
            var usuarioExiste = await _context.usuarios.AnyAsync(u => u.Id == encargue.UsuarioId);

            if (!productoExiste || !usuarioExiste)
            {
                return BadRequest(new
                {
                    errors = new Dictionary<string, string[]>
                {
                    { productoExiste ? null : "Producto", new[] { "El producto especificado no existe." } },
                    { usuarioExiste ? null : "Usuario", new[] { "El usuario especificado no existe." } }
                }.Where(kvp => kvp.Key != null)
                });
            }

            // Crear nuevo encargue
            var nuevoEncargue = new Encargue
            {
                ProductoId = encargue.ProductoId,
                UsuarioId = encargue.UsuarioId,
                Cantidad = encargue.Cantidad,
                FechaEncargue = DateTime.UtcNow
            };

            _context.encargues.Add(nuevoEncargue);
            await _context.SaveChangesAsync();

            // Cargar las relaciones después de guardar
            await _context.Entry(nuevoEncargue)
                .Reference(e => e.Producto)
                .LoadAsync();
            await _context.Entry(nuevoEncargue)
                .Reference(e => e.Usuario)
                .LoadAsync();

            return CreatedAtAction(nameof(GetEncargue), new { id = nuevoEncargue.Id }, nuevoEncargue);
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

        var existingEncargue = await _context.encargues.FindAsync(id);
        if (existingEncargue == null)
        {
            return NotFound();
        }

        // Verificar existencia de Producto y Usuario
        var productoExiste = await _context.productos.AnyAsync(p => p.Id == encargue.ProductoId);
        var usuarioExiste = await _context.usuarios.AnyAsync(u => u.Id == encargue.UsuarioId);

        if (!productoExiste || !usuarioExiste)
        {
            return BadRequest("Producto o Usuario no existe");
        }

        // Actualizar solo las propiedades permitidas
        existingEncargue.ProductoId = encargue.ProductoId;
        existingEncargue.UsuarioId = encargue.UsuarioId;
        existingEncargue.Cantidad = encargue.Cantidad;

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