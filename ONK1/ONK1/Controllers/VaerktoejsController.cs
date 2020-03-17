using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ONK1.Models;

namespace ONK1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaerktoejsController : ControllerBase
    {
        private readonly ONK1Context _context;

        public VaerktoejsController(ONK1Context context)
        {
            _context = context;
        }

        // GET: api/Vaerktoejs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vaerktoej>>> GetVaerktoej()
        {
            return await _context.Vaerktoej.ToListAsync();
        }

        // GET: api/Vaerktoejs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vaerktoej>> GetVaerktoej(int id)
        {
            var vaerktoej = await _context.Vaerktoej.FindAsync(id);

            if (vaerktoej == null)
            {
                return NotFound();
            }

            return vaerktoej;
        }

        // PUT: api/Vaerktoejs/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVaerktoej(int id, Vaerktoej vaerktoej)
        {
            if (id != vaerktoej.VTId)
            {
                return BadRequest();
            }

            _context.Entry(vaerktoej).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VaerktoejExists(id))
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

        // POST: api/Vaerktoejs
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Vaerktoej>> PostVaerktoej(Vaerktoej vaerktoej)
        {
            _context.Vaerktoej.Add(vaerktoej);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVaerktoej", new { id = vaerktoej.VTId }, vaerktoej);
        }

        // DELETE: api/Vaerktoejs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vaerktoej>> DeleteVaerktoej(int id)
        {
            var vaerktoej = await _context.Vaerktoej.FindAsync(id);
            if (vaerktoej == null)
            {
                return NotFound();
            }

            _context.Vaerktoej.Remove(vaerktoej);
            await _context.SaveChangesAsync();

            return vaerktoej;
        }

        private bool VaerktoejExists(int id)
        {
            return _context.Vaerktoej.Any(e => e.VTId == id);
        }
    }
}
