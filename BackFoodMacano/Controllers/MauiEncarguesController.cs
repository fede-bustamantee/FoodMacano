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

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<MauiEncargue>>> GetEncarguesByUser(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("User ID is required");
            }

            var encargues = await _context.mauiEncargue
                .Include(e => e.Detalles)
                    .ThenInclude(d => d.Producto)
                .Where(e => e.UserId == userId)
                .OrderByDescending(e => e.FechaEncargue)
                .ToListAsync();

            return Ok(encargues);
        }

        // GET: api/MauiEncargues/{id}/details
        [HttpGet("{id}/details")]
        public async Task<ActionResult<MauiEncargue>> GetEncargueWithDetails(int id)
        {
            var encargue = await _context.mauiEncargue
                .Include(e => e.Detalles)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (encargue == null)
            {
                return NotFound($"Encargue with ID {id} not found");
            }

            return Ok(encargue);
        }

        // GET: api/MauiEncargues/user/{userId}/withDetails
        [HttpGet("user/{userId}/withDetails")]
        public async Task<ActionResult<IEnumerable<MauiEncargue>>> GetEncarguesWithDetailsByUser(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("User ID is required");
            }

            var encargues = await _context.mauiEncargue
                .Include(e => e.Detalles)
                .Where(e => e.UserId == userId)
                .OrderByDescending(e => e.FechaEncargue)
                .ToListAsync();

            return Ok(encargues);
        }

        // Existing endpoints...
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MauiEncargue>>> GetMauiEncargues()
        {
            return await _context.mauiEncargue.ToListAsync();
        }

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

        [HttpPost]
        public async Task<ActionResult<MauiEncargue>> PostMauiEncargue(MauiEncargue mauiEncargue)
        {
            if (mauiEncargue == null || string.IsNullOrEmpty(mauiEncargue.UserId))
            {
                return BadRequest("Datos inválidos.");
            }

            if (mauiEncargue.Detalles == null || !mauiEncargue.Detalles.Any())
            {
                return BadRequest("El encargue debe incluir al menos un detalle.");
            }

            var strategy = _context.Database.CreateExecutionStrategy();

            try
            {
                await strategy.ExecuteAsync(async () =>
                {
                    using var transaction = await _context.Database.BeginTransactionAsync();
                    try
                    {
                        // Asegurarse de que los productos existen y cargar sus datos
                        foreach (var detalle in mauiEncargue.Detalles)
                        {
                            var producto = await _context.productos.FindAsync(detalle.ProductoId);
                            if (producto == null)
                            {
                                throw new InvalidOperationException($"Producto no encontrado: {detalle.ProductoId}");
                            }
                            detalle.Producto = producto;
                            detalle.NombreProducto = producto.Nombre;
                            detalle.PrecioUnitario = producto.Precio;
                        }

                        // Agregar el encargue y sus detalles
                        _context.mauiEncargue.Add(mauiEncargue);
                        await _context.SaveChangesAsync();

                        await transaction.CommitAsync();
                    }
                    catch
                    {
                        await transaction.RollbackAsync();
                        throw;
                    }
                });

                // Cargar el encargue completo para la respuesta
                var encargueCompleto = await _context.mauiEncargue
                    .Include(e => e.Detalles)
                    .ThenInclude(d => d.Producto)
                    .FirstOrDefaultAsync(e => e.Id == mauiEncargue.Id);

                return CreatedAtAction(nameof(GetMauiEncargue), new { id = mauiEncargue.Id }, encargueCompleto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

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