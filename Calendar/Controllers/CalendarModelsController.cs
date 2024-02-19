using Calendar.Data;
using Calendar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Calendar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarModelsController : ControllerBase
    {
        private readonly CalendarDbContext _context;

        public CalendarModelsController(CalendarDbContext context)
        {
            _context = context;
        }

        // GET: api/CalendarModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CalendarModel>>> GetCalendars()
        {
            if (_context.Calendars == null)
            {
                return NotFound();
            }
            return await _context.Calendars.ToListAsync();
        }

        // GET: api/CalendarModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CalendarModel>> GetCalendarModel(int id)
        {
            if (_context.Calendars == null)
            {
                return NotFound();
            }
            var calendarModel = await _context.Calendars.FindAsync(id);

            if (calendarModel == null)
            {
                return NotFound();
            }

            return calendarModel;
        }

        // PUT: api/CalendarModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalendarModel(int id, CalendarModel calendarModel)
        {
            if (id != calendarModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(calendarModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalendarModelExists(id))
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

        // POST: api/CalendarModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CalendarModel>> PostCalendarModel(CalendarModel calendarModel)
        {
            if (_context.Calendars == null)
            {
                return Problem("Entity set 'CalendarDbContext.Calendars'  is null.");
            }
            _context.Calendars.Add(calendarModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCalendarModel", new { id = calendarModel.Id }, calendarModel);
        }

        // DELETE: api/CalendarModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalendarModel(int id)
        {
            if (_context.Calendars == null)
            {
                return NotFound();
            }
            var calendarModel = await _context.Calendars.FindAsync(id);
            if (calendarModel == null)
            {
                return NotFound();
            }

            _context.Calendars.Remove(calendarModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CalendarModelExists(int id)
        {
            return (_context.Calendars?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
