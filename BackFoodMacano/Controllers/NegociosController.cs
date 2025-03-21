﻿using System;
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
    public class NegociosController : ControllerBase
    {
        private readonly FoodMacanoContext _context;

        public NegociosController(FoodMacanoContext context)
        {
            _context = context;
        }

        // GET: api/Negocios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Negocio>>> Getnegocios()
        {
            return await _context.negocios
            .Include(n => n.RedesSocial) // Incluye la relación con RedesSocial
            .ToListAsync();
        }

        // GET: api/Negocios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Negocio>> GetNegocio(int id)
        {
            var negocio = await _context.negocios
                .Include(n => n.RedesSocial) // Incluye la relación con RedesSocial
                .FirstOrDefaultAsync(n => n.Id == id);

            if (negocio == null)
            {
                return NotFound();
            }

            return negocio;
        }

        // PUT: api/Negocios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNegocio(int id, Negocio negocio)
        {
            if (id != negocio.Id)
            {
                return BadRequest();
            }

            _context.Entry(negocio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NegocioExists(id))
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

        // POST: api/Negocios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Negocio>> PostNegocio(Negocio negocio)
        {
            _context.negocios.Add(negocio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNegocio", new { id = negocio.Id }, negocio);
        }

        // DELETE: api/Negocios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNegocio(int id)
        {
            var negocio = await _context.negocios.FindAsync(id);
            if (negocio == null)
            {
                return NotFound();
            }

            _context.negocios.Remove(negocio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NegocioExists(int id)
        {
            return _context.negocios.Any(e => e.Id == id);
        }
    }
}
