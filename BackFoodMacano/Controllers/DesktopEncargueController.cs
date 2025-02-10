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
                // Validar mesa ocupada
                var encargueExistente = await _context.desktopEncargues
                    .AnyAsync(e => e.NumeroMesa == encargue.NumeroMesa);

                if (encargueExistente)
                    return Conflict($"Ya existe un encargue activo para la mesa {encargue.NumeroMesa}");

                // Validar productos
                foreach (var detalle in encargue.Detalles)
                {
                    var productoExiste = await _context.productos
                        .AnyAsync(p => p.Id == detalle.ProductoId);

                    if (!productoExiste)
                        return BadRequest($"Producto {detalle.ProductoId} no existe");
                }

                encargue.Total = encargue.Detalles.Sum(d => d.Total);
                encargue.FechaEncargue = DateTime.Now;

                _context.desktopEncargues.Add(encargue);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetEncargue), new { id = encargue.Id }, encargue);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error procesando encargue", error = ex.Message });
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEncargue(int id)
        {
            try
            {
                var encargue = await _context.desktopEncargues.FindAsync(id);
                if (encargue == null)
                {
                    return NotFound($"No se encontró el encargue con ID {id}");
                }

                _context.desktopEncargues.Remove(encargue);
                await _context.SaveChangesAsync();

                return Ok(new { message = $"Encargue con ID {id} eliminado exitosamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error interno al eliminar el encargue.", error = ex.Message });
            }
        }
    }
}