using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentACarAPI.Data;
using RentACarAPI.Models;

namespace RentACar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AraclarController : ControllerBase
    {
        private readonly RentACarContext _context;

        public AraclarController(RentACarContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Arac>>> GetAraclar()
        {
            return await _context.Araclar.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Arac>> GetArac(int id)
        {
            var arac = await _context.Araclar.FindAsync(id);

            if (arac == null)
            {
                return NotFound();
            }

            return arac;
        }

        [HttpPost]
        public async Task<ActionResult<Arac>> PostArac(Arac arac)
        {
            _context.Araclar.Add(arac);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetArac), new { arac.id }, arac);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutArac(int id, Arac arac)
        {
            if (id != arac.id)
            {
                return BadRequest();
            }

            _context.Entry(arac).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AracExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArac(int id)
        {
            var arac = await _context.Araclar.FindAsync(id);
            if (arac == null)
            {
                return NotFound();
            }

            _context.Araclar.Remove(arac);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AracExists(int id)
        {
            return _context.Araclar.Any(e => e.id == id);
        }
    }
}
