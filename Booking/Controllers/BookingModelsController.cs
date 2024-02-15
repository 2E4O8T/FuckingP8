using Booking.Data;
using Booking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingModelsController : ControllerBase
    {
        private readonly BookingDbContext _context;

        public BookingModelsController(BookingDbContext context)
        {
            _context = context;
        }

        // GET: api/BookingModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingModel>>> GetBookings()
        {
          if (_context.Bookings == null)
          {
              return NotFound();
          }
            return await _context.Bookings.ToListAsync();
        }

        // GET: api/BookingModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingModel>> GetBookingModel(int id)
        {
          if (_context.Bookings == null)
          {
              return NotFound();
          }
            var bookingModel = await _context.Bookings.FindAsync(id);

            if (bookingModel == null)
            {
                return NotFound();
            }

            return bookingModel;
        }

        // PUT: api/BookingModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookingModel(int id, BookingModel bookingModel)
        {
            if (id != bookingModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(bookingModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingModelExists(id))
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

        // POST: api/BookingModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookingModel>> PostBookingModel(BookingModel bookingModel)
        {
          if (_context.Bookings == null)
          {
              return Problem("Entity set 'BookingDbContext.Bookings'  is null.");
          }
            _context.Bookings.Add(bookingModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookingModel", new { id = bookingModel.Id }, bookingModel);
        }

        // DELETE: api/BookingModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookingModel(int id)
        {
            if (_context.Bookings == null)
            {
                return NotFound();
            }
            var bookingModel = await _context.Bookings.FindAsync(id);
            if (bookingModel == null)
            {
                return NotFound();
            }

            _context.Bookings.Remove(bookingModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookingModelExists(int id)
        {
            return (_context.Bookings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
