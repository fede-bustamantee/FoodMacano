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
        public async Task<ActionResult> PostEncargue([FromBody] List<DesktopEncargue> encargues)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (encargues == null || !encargues.Any())
                {
                    return BadRequest("La lista de encargues está vacía.");
                }

                string numeroMesa = encargues.First().NumeroMesa;

                // Verificar si ya existe un encargo para esta mesa
                bool encargueExistente = await _context.desktopEncargues
                    .AnyAsync(e => e.NumeroMesa == numeroMesa);

                if (encargueExistente)
                {
                    return Conflict($"Ya existe un encargo activo para la mesa {numeroMesa}");
                }

                // Guardar todos los productos en la base de datos
                await _context.desktopEncargues.AddRangeAsync(encargues);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Encargo registrado correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error interno al procesar el encargo.", error = ex.Message });
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

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEncargue(int id, [FromBody] DesktopEncargue encargue)
        {
            if (id != encargue.Id)
            {
                return BadRequest("El ID en la URL no coincide con el ID del objeto.");
            }

            var encargueExistente = await _context.desktopEncargues.FindAsync(id);
            if (encargueExistente == null)
            {
                return NotFound($"No se encontró un encargo con ID {id}");
            }

            try
            {
                // Actualizar los valores
                encargueExistente.ProductoId = encargue.ProductoId;
                encargueExistente.NombreProducto = encargue.NombreProducto;
                encargueExistente.Cantidad = encargue.Cantidad;
                encargueExistente.PrecioUnitario = encargue.PrecioUnitario;
                encargueExistente.Total = encargue.Total;

                _context.Entry(encargueExistente).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Ok(new { message = "Encargo actualizado correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error interno al actualizar el encargo.", error = ex.Message });
            }
        }

    }
}