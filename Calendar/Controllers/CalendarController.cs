using Microsoft.AspNetCore.Mvc;
using Calendar.Data;
using Calendar.Models;

namespace Calendar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalendarController : ControllerBase
    {
        private readonly CalendarDbContext _context;

        public CalendarController(CalendarDbContext context)
        {
            _context = context;
        }

        // GET: /api/calendar
        [HttpGet]
        public IEnumerable<CalendarModel> Get()
        {
            return _context.Calendars.ToList();
        }
    }
}
