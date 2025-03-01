using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackFoodMacano.DataContext;
using FoodMacanoServices.Models.Common;

namespace BackFoodMacano.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedeSocialesController : ControllerBase
    {
        private readonly FoodMacanoContext _context;

        public RedeSocialesController(FoodMacanoContext context)
        {
            _context = context;
        }

        // GET: api/RedeSociales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RedesSocial>>> GetredesSociales()
        {
            return await _context.redesSociales.ToListAsync();
        }

        // GET: api/RedeSociales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RedesSocial>> GetRedesSocial(int id)
        {
            var redesSocial = await _context.redesSociales.FindAsync(id);

            if (redesSocial == null)
            {
                return NotFound();
            }

            return redesSocial;
        }

        // PUT: api/RedeSociales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRedesSocial(int id, RedesSocial redesSocial)
        {
            if (id != redesSocial.Id)
            {
                return BadRequest();
            }

            _context.Entry(redesSocial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RedesSocialExists(id))
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

        // POST: api/RedeSociales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RedesSocial>> PostRedesSocial(RedesSocial redesSocial)
        {
            _context.redesSociales.Add(redesSocial);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRedesSocial", new { id = redesSocial.Id }, redesSocial);
        }

        // DELETE: api/RedeSociales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRedesSocial(int id)
        {
            var redesSocial = await _context.redesSociales.FindAsync(id);
            if (redesSocial == null)
            {
                return NotFound();
            }

            _context.redesSociales.Remove(redesSocial);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RedesSocialExists(int id)
        {
            return _context.redesSociales.Any(e => e.Id == id);
        }
    }
}
