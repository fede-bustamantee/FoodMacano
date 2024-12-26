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
    public class ProductosController : ControllerBase
    {
        private readonly FoodMacanoContext _context;

        public ProductosController(FoodMacanoContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> Getproductos([FromQuery] int? idCategoria)
        {
            // Incluimos la relación con Categoria
            var query = _context.productos
                                .Include(p => p.DescripcionProducto)
                                .Include(p => p.Categoria) 
                                .AsQueryable();

            if (idCategoria.HasValue)
            {
                query = query.Where(p => p.CategoriaId == idCategoria.Value);
            }

            return await query.ToListAsync();
        }

        [HttpGet("aleatorios")]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductosAleatorios()
        {
            // Obtener 7 productos aleatorios
            var productosAleatorios = await _context.productos
                .OrderBy(p => Guid.NewGuid())  // Orden aleatorio
                .Take(8)                       // Seleccionar 7 productos aleatorios
                .Include(p => p.DescripcionProducto) // Incluir la entidad relacionada
                .Include(c => c.Categoria)
                .ToListAsync();

            return productosAleatorios;
        }

        // GET: api/Productos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            // Incluir la entidad relacionada DescripcionProducto
            var producto = await _context.productos
                                         .Include(p => p.DescripcionProducto)
                                         .Include(c => c.Categoria)
                                         .FirstOrDefaultAsync(p => p.Id == id);

            if (producto == null)
            {
                return NotFound();
            }

            return producto;
        }

        // PUT: api/Productos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, Producto producto)
        {
            if (id != producto.Id)
            {
                return BadRequest();
            }

            _context.Entry(producto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoExists(id))
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

        // POST: api/Productos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        {
            _context.productos.Add(producto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProducto", new { id = producto.Id }, producto);
        }

        // DELETE: api/Productos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var producto = await _context.productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            _context.productos.Remove(producto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductoExists(int id)
        {
            return _context.productos.Any(e => e.Id == id);
        }
    }
}
