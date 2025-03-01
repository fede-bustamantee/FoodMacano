using BackFoodMacano.DataContext;
using FoodMacanoServices.Models;
using FoodMacanoServices.Models.Cart;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodMacanoServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly FoodMacanoContext _context;

        public UsuariosController(FoodMacanoContext context)
        {
            _context = context;
        }
        // GET: api/Usuarios/email/{email}
        [HttpGet("email/{email}")]
        public async Task<ActionResult<Usuario>> GetUsuarioByEmail(string email)
        {
            var usuario = await _context.usuarios
                .FirstOrDefaultAsync(u => u.Email == email);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.usuarios.ToListAsync();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.usuarios
                .FirstOrDefaultAsync(u => u.Id == id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // POST: api/Usuarios
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            _context.usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);
        }

        // PUT: api/Usuarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
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

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/Usuarios/5/Encargues
        [HttpGet("{id}/Encargues")]
        public async Task<ActionResult<IEnumerable<Encargue>>> GetEncargues(int id)
        {
            var encargues = await _context.encargues
                .Where(e => e.UsuarioId == id)
                .Include(e => e.EncargueDetalles)
                .ThenInclude(ed => ed.Producto)
                .ToListAsync();

            if (encargues == null)
            {
                return NotFound();
            }

            return encargues;
        }

        // POST: api/Usuarios/5/Encargues
        [HttpPost("{id}/Encargues")]
        public async Task<ActionResult<Encargue>> PostEncargue(int id, Encargue encargue)
        {
            encargue.UsuarioId = id;
            _context.encargues.Add(encargue);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEncargues), new { id = encargue.UsuarioId }, encargue);
        }

        // GET: api/Usuarios/5/Carrito
        [HttpGet("{id}/Carrito")]
        public async Task<ActionResult<IEnumerable<CarritoCompra>>> GetCarrito(int id)
        {
            var carrito = await _context.carritoCompra
                .Where(c => c.UsuarioId == id)
                .Include(c => c.Producto)
                .ToListAsync();

            if (carrito == null)
            {
                return NotFound();
            }

            return carrito;
        }

        // POST: api/Usuarios/5/Carrito
        [HttpPost("{id}/Carrito")]
        public async Task<ActionResult<CarritoCompra>> PostCarrito(int id, CarritoCompra carritoItem)
        {
            carritoItem.UsuarioId = id;
            var existingItem = await _context.carritoCompra
                .FirstOrDefaultAsync(c => c.ProductoId == carritoItem.ProductoId && c.UsuarioId == id);

            if (existingItem != null)
            {
                existingItem.Cantidad += carritoItem.Cantidad;
                _context.Entry(existingItem).State = EntityState.Modified;
            }
            else
            {
                _context.carritoCompra.Add(carritoItem);
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCarrito), new { id = carritoItem.UsuarioId }, carritoItem);
        }

        private bool UsuarioExists(int id)
        {
            return _context.usuarios.Any(u => u.Id == id);
        }
    }
}
