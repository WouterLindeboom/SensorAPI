using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SensorAPI.Models;

namespace SensorAPI.Controllers
{
    [Route("api/measurements")]
    [ApiController]
    public class MeasurementsController : ControllerBase
    {
        private readonly ApiContext _context;

        public MeasurementsController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Measurements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Measurement>>> GetMeasurements()
        {
            return await _context.Measurements.ToListAsync();
        }

        // GET: api/Measurements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Measurement>> GetMeasurement(int id)
        {
            var measurement = await _context.Measurements.FindAsync(id);

            if (measurement == null)
            {
                return NotFound();
            }

            return measurement;
        }

        // POST: api/Measurements
        [HttpPost]
        public async Task<ActionResult<Measurement>> PostMeasurement(Measurement measurement)
        {
            if (!CityExists(measurement.CityId))
            {
                return new ObjectResult(new { error = "Invalid city ID" }) { StatusCode = 500 };
            }
            else
            {
                _context.Measurements.Add(measurement);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetMeasurement", new { id = measurement.Id }, measurement);
            }
            
        }

        private bool CityExists(int id)
        {
            return _context.Cities.Any(m => m.Id == id);
        }
    }
}
