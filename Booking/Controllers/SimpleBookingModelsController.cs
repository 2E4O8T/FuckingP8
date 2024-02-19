using Booking.Data;
using Booking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimpleBookingModelsController : ControllerBase
    {
        private readonly BookingDbContext _context;

        public SimpleBookingModelsController(BookingDbContext context)
        {
            _context = context;
        }

        // GET: api/SimpleBookingModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SimpleBookingModel>>> GetAllBookings()
        {
            return await _context.SimpleBookings.ToListAsync();
        }

        // GET: api/SimpleBookingModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SimpleBookingModel>> GetBookingById(int id)
        {
            var simpleBookingModel = await _context.SimpleBookings.FindAsync(id);

            if (simpleBookingModel == null)
            {
                return NotFound();
            }

            return simpleBookingModel;
        }

        // PUT: api/SimpleBookingModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBookingById(int id, SimpleBookingModel simpleBookingModel)
        {
            if (id != simpleBookingModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(simpleBookingModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(id))
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

        // POST: api/SimpleBookingModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SimpleBookingModel>> CreateBooking(SimpleBookingModel simpleBookingModel)
        {
            _context.SimpleBookings.Add(simpleBookingModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookingById", new { id = simpleBookingModel.Id }, simpleBookingModel);
        }

        // DELETE: api/SimpleBookingModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookingById(int id)
        {
            var simpleBookingModel = await _context.SimpleBookings.FindAsync(id);
            if (simpleBookingModel == null)
            {
                return NotFound();
            }

            _context.SimpleBookings.Remove(simpleBookingModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookingExists(int id)
        {
            return _context.SimpleBookings.Any(e => e.Id == id);
        }
    }
}