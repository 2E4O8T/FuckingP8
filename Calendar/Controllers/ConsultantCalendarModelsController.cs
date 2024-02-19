using Calendar.Data;
using Calendar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Calendar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultantCalendarModelsController : ControllerBase
    {
        private readonly CalendarDbContext _context;

        public ConsultantCalendarModelsController(CalendarDbContext context)
        {
            _context = context;
        }

        // GET: api/ConsultantCalendarModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConsultantCalendarModel>>> GetConsultantsCalendars()
        {
            if (_context.ConsultantsCalendars == null)
            {
                return NotFound();
            }
            return await _context.ConsultantsCalendars.ToListAsync();
        }

        // GET: api/ConsultantCalendarModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConsultantCalendarModel>> GetConsultantCalendarModel(int id)
        {
            if (_context.ConsultantsCalendars == null)
            {
                return NotFound();
            }
            var consultantCalendarModel = await _context.ConsultantsCalendars.FindAsync(id);

            if (consultantCalendarModel == null)
            {
                return NotFound();
            }

            return consultantCalendarModel;
        }

        // PUT: api/ConsultantCalendarModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsultantCalendarModel(int id, ConsultantCalendarModel consultantCalendarModel)
        {
            if (id != consultantCalendarModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(consultantCalendarModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsultantCalendarModelExists(id))
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

        // POST: api/ConsultantCalendarModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ConsultantCalendarModel>> PostConsultantCalendarModel(ConsultantCalendarModel consultantCalendarModel)
        {
            if (_context.ConsultantsCalendars == null)
            {
                return Problem("Entity set 'CalendarDbContext.ConsultantsCalendars'  is null.");
            }
            _context.ConsultantsCalendars.Add(consultantCalendarModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConsultantCalendarModel", new { id = consultantCalendarModel.Id }, consultantCalendarModel);
        }

        // DELETE: api/ConsultantCalendarModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsultantCalendarModel(int id)
        {
            if (_context.ConsultantsCalendars == null)
            {
                return NotFound();
            }
            var consultantCalendarModel = await _context.ConsultantsCalendars.FindAsync(id);
            if (consultantCalendarModel == null)
            {
                return NotFound();
            }

            _context.ConsultantsCalendars.Remove(consultantCalendarModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConsultantCalendarModelExists(int id)
        {
            return (_context.ConsultantsCalendars?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        // Add check availability
        [HttpGet("CheckAvailability")]
        public async Task<ActionResult<bool>> CheckAvailability(string consultantName, DateTime appointmentDate)
        {
            var isAvailable = await _context.ConsultantsCalendars
                                           .AnyAsync(c => c.ConsultantName == consultantName && c.AppointmentDate == appointmentDate);

            return !isAvailable;
        }


        // Add method GetAppointments
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<ConsultantCalendarDto>>> GetAppointments(string consultantName, DateTime appointmentDate)
        //{
        //    try
        //    {
        //        var appointments = await _context.ConsultantsCalendars
        //                                    .Where(b => b.ConsultantName == consultantName && b.AppointmentDate.Date == appointmentDate.Date)
        //                                    .ToListAsync();

        //        //return appointments.ToListAsync();

        //        return appointments.Select(a => new ConsultantCalendarDto
        //        {
        //            ConsultantName = a.ConsultantName,
        //            AppointmentDate = a.AppointmentDate
        //        }).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception
        //        Console.WriteLine(ex.Message);

        //        // Return a 500 Internal Server Error response
        //        return StatusCode(500, "An error occurred while processing your request.");
        //    }
        //}

    }
}
