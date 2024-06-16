using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhnomPenhVaccineCardSystem.Data;
using PhnomPenhVaccineCardSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhnomPenhVaccineCardSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccineCardsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VaccineCardsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/VaccineCards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VaccineCard>>> GetVaccineCards()
        {
            return await _context.VaccineCards.Include(v => v.Customer).ToListAsync();
        }

        // GET: api/VaccineCards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VaccineCard>> GetVaccineCard(int id)
        {
            var vaccineCard = await _context.VaccineCards.Include(v => v.Customer).FirstOrDefaultAsync(v => v.VaccineCardId == id);

            if (vaccineCard == null)
            {
                return NotFound();
            }

            return vaccineCard;
        }

        // POST: api/VaccineCards
        [HttpPost]
        public async Task<ActionResult<VaccineCard>> PostVaccineCard(VaccineCard vaccineCard)
        {
            _context.VaccineCards.Add(vaccineCard);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVaccineCard), new { id = vaccineCard.VaccineCardId }, vaccineCard);
        }

        // PUT: api/VaccineCards/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVaccineCard(int id, VaccineCard vaccineCard)
        {
            if (id != vaccineCard.VaccineCardId)
            {
                return BadRequest();
            }

            _context.Entry(vaccineCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VaccineCardExists(id))
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

        // DELETE: api/VaccineCards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVaccineCard(int id)
        {
            var vaccineCard = await _context.VaccineCards.FindAsync(id);
            if (vaccineCard == null)
            {
                return NotFound();
            }

            _context.VaccineCards.Remove(vaccineCard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VaccineCardExists(int id)
        {
            return _context.VaccineCards.Any(e => e.VaccineCardId == id);
        }
    }
}
