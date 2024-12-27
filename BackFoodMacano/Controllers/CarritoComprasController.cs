using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackFoodMacano.DataContext;
using FoodMacanoServices.Models;

namespace BackFoodMacano.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoComprasController : ControllerBase
    {
        private readonly FoodMacanoContext _context;

        public CarritoComprasController(FoodMacanoContext context)
        {
            _context = context;
        }

        // GET: api/CarritoCompras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarritoCompra>>> GetcarritoCompra()
        {
            return await _context.carritoCompra
                .Include(c => c.Producto)
                .ToListAsync();
        }

        // GET: api/CarritoCompras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarritoCompra>> GetCarritoCompra(int id)
        {
            var carritoCompra = await _context.carritoCompra.FindAsync(id);

            if (carritoCompra == null)
            {
                return NotFound();
            }

            return carritoCompra;
        }

        // PUT: api/CarritoCompras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarritoCompra(int id, CarritoCompra carritoCompra)
        {
            if (id != carritoCompra.Id)
            {
                return BadRequest();
            }

            _context.Entry(carritoCompra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarritoCompraExists(id))
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

        // POST: api/CarritoCompras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarritoCompra>> PostCarritoCompra(CarritoCompra carritoCompra)
        {
            // Validación de los datos recibidos
            if (carritoCompra == null || carritoCompra.ProductoId <= 0 || carritoCompra.UsuarioId <= 0)
            {
                return BadRequest("Datos inválidos");
            }

            // Agrega el objeto al contexto y guarda los cambios
            _context.carritoCompra.Add(carritoCompra);
            await _context.SaveChangesAsync();

            // Devuelve el recurso creado
            return CreatedAtAction("GetCarritoCompra", new { id = carritoCompra.Id }, carritoCompra);
        }


        // DELETE: api/CarritoCompras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarritoCompra(int id)
        {
            var carritoCompra = await _context.carritoCompra.FindAsync(id);
            if (carritoCompra == null)
            {
                return NotFound();
            }

            _context.carritoCompra.Remove(carritoCompra);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarritoCompraExists(int id)
        {
            return _context.carritoCompra.Any(e => e.Id == id);
        }
    }
}
