using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackFoodMacano.DataContext;
using FoodMacanoServices.Models;

namespace BackFoodMacano.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DescripcionProductosController : ControllerBase
    {
        private readonly FoodMacanoContext _context;

        public DescripcionProductosController(FoodMacanoContext context)
        {
            _context = context;
        }

        // GET: api/DescripcionProductos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DescripcionProducto>>> GetdescripcionProductos()
        {
            return await _context.descripcionProductos.ToListAsync();
        }

        // GET: api/DescripcionProductos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DescripcionProducto>> GetDescripcionProducto(int id)
        {
            var descripcionProducto = await _context.descripcionProductos.FindAsync(id);

            if (descripcionProducto == null)
            {
                return NotFound();
            }

            return descripcionProducto;
        }

        // PUT: api/DescripcionProductos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDescripcionProducto(int id, DescripcionProducto descripcionProducto)
        {
            if (id != descripcionProducto.Id)
            {
                return BadRequest();
            }

            _context.Entry(descripcionProducto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DescripcionProductoExists(id))
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

        // POST: api/DescripcionProductos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DescripcionProducto>> PostDescripcionProducto(DescripcionProducto descripcionProducto)
        {
            _context.descripcionProductos.Add(descripcionProducto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDescripcionProducto", new { id = descripcionProducto.Id }, descripcionProducto);
        }

        // DELETE: api/DescripcionProductos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDescripcionProducto(int id)
        {
            var descripcionProducto = await _context.descripcionProductos.FindAsync(id);
            if (descripcionProducto == null)
            {
                return NotFound();
            }

            _context.descripcionProductos.Remove(descripcionProducto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DescripcionProductoExists(int id)
        {
            return _context.descripcionProductos.Any(e => e.Id == id);
        }
    }
}
