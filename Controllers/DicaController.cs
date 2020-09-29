using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EduxAPI.Contexts;
using EduxAPI.Domains;


namespace EduxAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DicaController
    {
        private readonly EduxContext _context;

        public DicaController(EduxContext context)
        {
            _context = context;
        }

        // GET: api/Dica
        [HttpGet]
        public async Task<ActionResult<Dica>> GetDica()
        {
            return await _context.Dica.ToListAsync();
        }
        // GET: api/Dica/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dica>> GetDica(int id);
        {
            var dica = await _context.Dica.FindAsync(id);

            if (dica == null)
            { 
            return NotFound();
            }
            
            return dica;
        }

        // PUT: api/Dica/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDica(int id, Dica dica)
        {
            if (id != dica.IdDica)
            {
                return BadRequest();
            }
        
            _context.Entry(dica).State = EntityState.Modified;
                
            try
            {
                await _context.SaveChangesAsync();
            }
            
            catch (DbUpdateConcurrencyException)
            {
                if (!DicaExists(id))
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
        // POST: api/Dica
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Dica>> PostDica(Dica dica)
        {
        _context.Dica.Add(dica);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetDica", new { id = dica.IdDica }, dica);
        }


        // DELETE: api/Dica/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Dica>> DeleteDica(int id)
        {
            var dica = await _context.Dica.FindAsync(id);
            if (dica == null)
            {
                return NotFound();
            }

            _context.Dica.Remove(dica);
            await _context.SaveChangesAsync();

            return dica;
        }

        private bool DicaExists(int id)
        {
            return _context.Dica.Any(e => e.IdDica == id);

            }    
    }
}
