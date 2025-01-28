using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackFoodMacano.DataContext;
using FoodMacanoServices.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFoodMacano.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MauiEncarguesController : ControllerBase
    {
        private readonly FoodMacanoContext _context;

        public MauiEncarguesController(FoodMacanoContext context)
        {
            _context = context;
        }

        // GET: api/MauiEncargues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MauiEncargue>>> GetMauiEncargues()
        {
            // Devuelve todos los encargues con paginación opcional en caso de alto volumen de datos
            return await _context.mauiEncargue.ToListAsync();
        }

        // GET: api/MauiEncargues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MauiEncargue>> GetMauiEncargue(int id)
        {
            var mauiEncargue = await _context.mauiEncargue.FindAsync(id);

            if (mauiEncargue == null)
            {
                return NotFound();
            }

            return mauiEncargue;
        }

        // PUT: api/MauiEncargues/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMauiEncargue(int id, MauiEncargue mauiEncargue)
        {
            if (id != mauiEncargue.Id)
            {
                return BadRequest();
            }

            _context.Entry(mauiEncargue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MauiEncargueExists(id))
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

        // POST: api/MauiEncargues
        [HttpPost]
        public async Task<ActionResult<MauiEncargue>> PostMauiEncargue(MauiEncargue mauiEncargue)
        {
            if (mauiEncargue == null || string.IsNullOrEmpty(mauiEncargue.UserId))
            {
                return BadRequest("Datos inválidos.");
            }

            _context.mauiEncargue.Add(mauiEncargue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMauiEncargue", new { id = mauiEncargue.Id }, mauiEncargue);
        }

        // DELETE: api/MauiEncargues/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMauiEncargue(int id)
        {
            var mauiEncargue = await _context.mauiEncargue.FindAsync(id);
            if (mauiEncargue == null)
            {
                return NotFound();
            }

            _context.mauiEncargue.Remove(mauiEncargue);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MauiEncargueExists(int id)
        {
            return _context.mauiEncargue.Any(e => e.Id == id);
        }
    }
}
