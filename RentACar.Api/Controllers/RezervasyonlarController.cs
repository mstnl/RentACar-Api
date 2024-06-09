using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentACarAPI.Data;
using RentACarAPI.Models;

namespace RentACarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RezervasyonlarController : ControllerBase
    {
        private readonly RentACarContext _context;

        public RezervasyonlarController(RentACarContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rezervasyon>>> GetRezervasyonlar()
        {
            return await _context.Rezervasyonlar.Include(r => r.Kullanici).Include(r => r.Arac).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Rezervasyon>> GetRezervasyon(int Id)
        {
            var rezervasyon = await _context.Rezervasyonlar.Include(r => r.Kullanici).Include(r => r.Arac).FirstOrDefaultAsync(r => r.Id == Id);

            if (rezervasyon == null)
            {
                return NotFound();
            }

            return rezervasyon;
        }

        [HttpPost]
        public async Task<ActionResult<Rezervasyon>> PostRezervasyon(Rezervasyon rezervasyon)
        {
            _context.Rezervasyonlar.Add(rezervasyon);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRezervasyon), new { Id = rezervasyon.Id }, rezervasyon);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRezervasyon(int Id, Rezervasyon rezervasyon)
        {
            if (Id != rezervasyon.Id)
            {
                return BadRequest();
            }

            _context.Entry(rezervasyon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RezervasyonExists(Id))
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

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteRezervasyon(int Id)
        {
            var rezervasyon = await _context.Rezervasyonlar.FindAsync(Id);
            if (rezervasyon == null)
            {
                return NotFound();
            }

            _context.Rezervasyonlar.Remove(rezervasyon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RezervasyonExists(int Id)
        {
            return _context.Rezervasyonlar.Any(e => e.Id == Id);
        }
    }
}
