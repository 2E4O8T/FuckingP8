using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Booking.Data;
using Booking.Models;

namespace Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultantModelsController : ControllerBase
    {
        private readonly BookingDbContext _context;

        public ConsultantModelsController(BookingDbContext context)
        {
            _context = context;
        }

        // GET: api/ConsultantModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConsultantModel>>> GetConsultants()
        {
          if (_context.Consultants == null)
          {
              return NotFound();
          }
            return await _context.Consultants.ToListAsync();
        }

        // GET: api/ConsultantModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConsultantModel>> GetConsultantModel(int id)
        {
          if (_context.Consultants == null)
          {
              return NotFound();
          }
            var consultantModel = await _context.Consultants.FindAsync(id);

            if (consultantModel == null)
            {
                return NotFound();
            }

            return consultantModel;
        }

        // PUT: api/ConsultantModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsultantModel(int id, ConsultantModel consultantModel)
        {
            if (id != consultantModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(consultantModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsultantModelExists(id))
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

        // POST: api/ConsultantModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ConsultantModel>> PostConsultantModel(ConsultantModel consultantModel)
        {
          if (_context.Consultants == null)
          {
              return Problem("Entity set 'BookingDbContext.Consultants'  is null.");
          }
            _context.Consultants.Add(consultantModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConsultantModel", new { id = consultantModel.Id }, consultantModel);
        }

        // DELETE: api/ConsultantModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsultantModel(int id)
        {
            if (_context.Consultants == null)
            {
                return NotFound();
            }
            var consultantModel = await _context.Consultants.FindAsync(id);
            if (consultantModel == null)
            {
                return NotFound();
            }

            _context.Consultants.Remove(consultantModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConsultantModelExists(int id)
        {
            return (_context.Consultants?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
