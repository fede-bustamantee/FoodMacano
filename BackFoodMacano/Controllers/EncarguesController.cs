using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackFoodMacano.DataContext;
using FoodMacanoServices.Models;

namespace BackFoodMacano.Controllers
{
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
        public async Task<ActionResult<IEnumerable<Encargue>>> Getencargues()
        {
            return await _context.encargues
                         .ToListAsync();
        }

        // GET: api/Encargues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Encargue>> GetEncargue(int id)
        {
            var encargue = await _context.encargues
                                 .FirstOrDefaultAsync(e => e.Id == id);

            if (encargue == null)
            {
                return NotFound();
            }

            return encargue;
        }

        // PUT: api/Encargues/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEncargue(int id, Encargue encargue)
        {
            if (id != encargue.Id)
            {
                return BadRequest();
            }

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
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Encargues
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Encargue>> PostEncargue(Encargue encargue)
        {
            if (encargue == null || encargue.UsuarioId <= 0 || encargue.ProductoId <= 0 || encargue.Cantidad <= 0)
            {
                return BadRequest(new
                {
                    Message = "Datos inválidos o incompletos.",
                    Errors = new
                    {
                        Usuario = encargue.UsuarioId <= 0 ? "El campo Usuario es requerido." : null,
                        Producto = encargue.ProductoId <= 0 ? "El campo Producto es requerido." : null,
                    }
                });
            }

            try
            {
                _context.encargues.Add(encargue);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetEncargue), new { id = encargue.Id }, encargue);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
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
}
