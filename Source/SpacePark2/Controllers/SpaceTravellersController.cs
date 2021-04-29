using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpacePark2;
using SpacePark2.Models;

namespace SpacePark2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpaceTravellersController : ControllerBase
    {
        private readonly SpaceParkContext _context;

        public SpaceTravellersController(SpaceParkContext context)
        {
            _context = context;
        }

        // GET: api/SpaceTravellers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpaceTraveller>>> GetSpaceTraveller()
        {

            return await _context.SpaceTraveller.ToListAsync();
            
        }

        // GET: api/SpaceTravellers/name
        [HttpGet("{name}")]
        public async Task<ActionResult<SpaceTraveller>> GetSpaceTraveller(string name)
        {
            var spaceTraveller = await _context.SpaceTraveller.FindAsync(name);

            if (spaceTraveller == null)
            {
                return NotFound();
            }

            return spaceTraveller;
        }

        // PUT: api/SpaceTravellers/name
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{name}")]
        public async Task<IActionResult> PutSpaceTraveller(string name, SpaceTraveller spaceTraveller)
        {
            if (name != spaceTraveller.Name)
            {
                return BadRequest();
            }

            _context.Entry(spaceTraveller).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpaceTravellerExists(name))
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

        // POST: api/SpaceTravellers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SpaceTraveller>> PostSpaceTraveller(SpaceTraveller spaceTraveller)
        {
            _context.SpaceTraveller.Add(spaceTraveller);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpaceTraveller", new { name = spaceTraveller.Name }, spaceTraveller);
        }

        //// DELETE: api/SpaceTravellers/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteSpaceTraveller(int id)
        //{
        //    var spaceTraveller = await _context.SpaceTraveller.FindAsync(id);
        //    if (spaceTraveller == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.SpaceTraveller.Remove(spaceTraveller);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool SpaceTravellerExists(string name)
        {
            return _context.SpaceTraveller.Any(e => e.Name == name);
        }
    }
}
