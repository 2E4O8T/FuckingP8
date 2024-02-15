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
    public class PatientModelsController : ControllerBase
    {
        private readonly BookingDbContext _context;

        public PatientModelsController(BookingDbContext context)
        {
            _context = context;
        }

        // GET: api/PatientModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientModel>>> GetPatients()
        {
          if (_context.Patients == null)
          {
              return NotFound();
          }
            return await _context.Patients.ToListAsync();
        }

        // GET: api/PatientModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientModel>> GetPatientModel(int id)
        {
          if (_context.Patients == null)
          {
              return NotFound();
          }
            var patientModel = await _context.Patients.FindAsync(id);

            if (patientModel == null)
            {
                return NotFound();
            }

            return patientModel;
        }

        // PUT: api/PatientModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatientModel(int id, PatientModel patientModel)
        {
            if (id != patientModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(patientModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientModelExists(id))
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

        // POST: api/PatientModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PatientModel>> PostPatientModel(PatientModel patientModel)
        {
          if (_context.Patients == null)
          {
              return Problem("Entity set 'BookingDbContext.Patients'  is null.");
          }
            _context.Patients.Add(patientModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPatientModel", new { id = patientModel.Id }, patientModel);
        }

        // DELETE: api/PatientModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatientModel(int id)
        {
            if (_context.Patients == null)
            {
                return NotFound();
            }
            var patientModel = await _context.Patients.FindAsync(id);
            if (patientModel == null)
            {
                return NotFound();
            }

            _context.Patients.Remove(patientModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PatientModelExists(int id)
        {
            return (_context.Patients?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
