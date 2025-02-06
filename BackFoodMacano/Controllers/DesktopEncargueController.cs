using BackFoodMacano.DataContext;
using FoodMacanoServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackFoodMacano.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesktopEncargueController : ControllerBase
    {
        private readonly FoodMacanoContext _context;

        public DesktopEncargueController(FoodMacanoContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<DesktopEncargue>> PostEncargue([FromBody] DesktopEncargue encargue)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Validar si la mesa ya tiene un encargo activo
                var existeEncargue = await _context.desktopEncargues
                    .AnyAsync(e => e.NumeroMesa == encargue.NumeroMesa);

                if (existeEncargue)
                {
                    return Conflict($"La mesa {encargue.NumeroMesa} ya tiene un encargo activo.");
                }

                _context.desktopEncargues.Add(encargue);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetEncargue), new { id = encargue.Id }, encargue);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error interno al procesar el encargue.", error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DesktopEncargue>> GetEncargue(int id)
        {
            var encargue = await _context.desktopEncargues
                .FirstOrDefaultAsync(e => e.Id == id);

            if (encargue == null)
            {
                return NotFound();
            }

            return encargue;
        }

        // Método opcional para obtener todos los encargues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DesktopEncargue>>> GetEncargues()
        {
            return await _context.desktopEncargues.ToListAsync();
        }

        // Método opcional para obtener encargues por número de mesa
        [HttpGet("mesa/{numeroMesa}")]
        public async Task<ActionResult<IEnumerable<DesktopEncargue>>> GetEncarguesPorMesa(string numeroMesa)
        {
            var encargues = await _context.desktopEncargues
                .Where(e => e.NumeroMesa == numeroMesa)
                .ToListAsync();

            if (!encargues.Any())
            {
                return NotFound($"No se encontraron encargues para la mesa {numeroMesa}");
            }

            return encargues;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEncargue(int id, [FromBody] DesktopEncargue encargue)
        {
            if (id != encargue.Id)
            {
                return BadRequest("El ID del encargue no coincide con el ID de la solicitud.");
            }

            var encargueExistente = await _context.desktopEncargues.FindAsync(id);
            if (encargueExistente == null)
            {
                return NotFound("Encargue no encontrado.");
            }

            encargueExistente.NumeroMesa = encargue.NumeroMesa;
            encargueExistente.ProductoId = encargue.ProductoId;
            encargueExistente.NombreProducto = encargue.NombreProducto;
            encargueExistente.Cantidad = encargue.Cantidad;
            encargueExistente.PrecioUnitario = encargue.PrecioUnitario;
            encargueExistente.Total = encargue.Total;
            encargueExistente.FechaEncargue = encargue.FechaEncargue;

            try
            {
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al actualizar el encargue.", error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEncargue(int id)
        {
            var encargue = await _context.desktopEncargues.FindAsync(id);
            if (encargue == null)
            {
                return NotFound("Encargue no encontrado.");
            }

            _context.desktopEncargues.Remove(encargue);

            try
            {
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al eliminar el encargue.", error = ex.Message });
            }
        }
    }
}