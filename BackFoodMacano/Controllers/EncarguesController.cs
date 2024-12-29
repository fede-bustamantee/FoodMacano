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

            // Verificar que existan el producto y usuario
            var producto = await _context.productos.FindAsync(encargue.ProductoId);
            var usuario = await _context.usuarios.FindAsync(encargue.UsuarioId);

            if (producto == null || usuario == null)
            {
                var errors = new Dictionary<string, string[]>();
                if (producto == null)
                    errors.Add("Producto", new[] { "El producto especificado no existe." });
                if (usuario == null)
                    errors.Add("Usuario", new[] { "El usuario especificado no existe." });
                return BadRequest(new { errors });
            }

            // Crear nuevo encargue con las relaciones correctas
            var nuevoEncargue = new Encargue
            {
                ProductoId = encargue.ProductoId,
                UsuarioId = encargue.UsuarioId,
                Cantidad = encargue.Cantidad,
                FechaEncargue = DateTime.UtcNow,
                // No es necesario asignar las navegaciones completas
                // EF Core las manejará automáticamente
            };

            _context.encargues.Add(nuevoEncargue);
            await _context.SaveChangesAsync();

            // Cargar las relaciones para la respuesta
            await _context.Entry(nuevoEncargue)
                .Reference(e => e.Producto)
                .LoadAsync();
            await _context.Entry(nuevoEncargue)
                .Reference(e => e.Usuario)
                .LoadAsync();

            return CreatedAtAction(
                nameof(GetEncargue),
                new { id = nuevoEncargue.Id },
                nuevoEncargue);
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

        // Verificar que existan el producto y usuario
        if (!await _context.productos.AnyAsync(p => p.Id == encargue.ProductoId) ||
            !await _context.usuarios.AnyAsync(u => u.Id == encargue.UsuarioId))
        {
            return BadRequest("Producto o Usuario no existe");
        }

        // Obtener el encargue existente
        var encargueExistente = await _context.encargues.FindAsync(id);
        if (encargueExistente == null)
        {
            return NotFound();
        }

        // Actualizar solo las propiedades permitidas
        encargueExistente.ProductoId = encargue.ProductoId;
        encargueExistente.UsuarioId = encargue.UsuarioId;
        encargueExistente.Cantidad = encargue.Cantidad;
        // No actualizamos FechaEncargue para mantener la original

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