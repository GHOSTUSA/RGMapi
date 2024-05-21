using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RGMapi.Models.EntityFramework;

namespace RGMapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiensController : ControllerBase
    {
        private readonly RgmContext _context;

        public LiensController(RgmContext context)
        {
            _context = context;
        }

        // GET: api/Liens    re
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lien>>> GetLiens()
        {
            return await _context.Liens.ToListAsync();
        }

        // GET: api/Liens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lien>> GetLien(int id)
        {
            var lien = await _context.Liens.FindAsync(id);

            if (lien == null)
            {
                return NotFound();
            }

            return lien;
        }

        // PUT: api/Liens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLien(int id, Lien lien)
        {
            if (id != lien.Lienid)
            {
                return BadRequest();
            }

            _context.Entry(lien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LienExists(id))
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

        // POST: api/Liens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Lien>> PostLien(Lien lien)
        {
            _context.Liens.Add(lien);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLien", new { id = lien.Lienid }, lien);
        }

        // DELETE: api/Liens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLien(int id)
        {
            var lien = await _context.Liens.FindAsync(id);
            if (lien == null)
            {
                return NotFound();
            }

            _context.Liens.Remove(lien);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LienExists(int id)
        {
            return _context.Liens.Any(e => e.Lienid == id);
        }
    }
}
