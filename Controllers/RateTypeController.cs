using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeChinhPhucToan_BE.Models;
using BeChinhPhucToan_BE.Data;

namespace BeChinhPhucToan_BE.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RateTypeController : ControllerBase
    {
        private readonly DataContext _context;

        public RateTypeController(DataContext context)
        {
            _context = context;
        }

        // GET: /RateType
        [HttpGet]
        public async Task<ActionResult<List<RateType>>> GetAllRateTypes()
        {
            var rateTypes = await _context.RateTypes.ToListAsync();
            return Ok(rateTypes);
        }

        // GET: /RateType/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<RateType>> GetRateTypeById(int id)
        {
            var rateType = await _context.RateTypes.FindAsync(id);

            if (rateType == null)
                return NotFound(new { message = "RateType not found!" });

            return Ok(rateType);
        }

        // POST: /RateType
        [HttpPost]
        public async Task<ActionResult> CreateRateType([FromBody] RateType rateType)
        {
            if (rateType == null || string.IsNullOrEmpty(rateType.name))
                return BadRequest(new { message = "Invalid input data!" });

            _context.RateTypes.Add(rateType);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRateTypeById), new { id = rateType.id }, rateType);
        }

        // PUT: /RateType/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRateType(int id, [FromBody] RateType updatedRateType)
        {
            var rateType = await _context.RateTypes.FindAsync(id);

            if (rateType == null)
                return NotFound(new { message = "RateType not found!" });

            if (string.IsNullOrEmpty(updatedRateType.name))
                return BadRequest(new { message = "RateType name cannot be empty!" });

            // Update fields
            rateType.name = updatedRateType.name;

            _context.RateTypes.Update(rateType);
            await _context.SaveChangesAsync();

            return Ok(new { message = "RateType updated successfully!" });
        }

        // DELETE: /RateType/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRateType(int id)
        {
            var rateType = await _context.RateTypes.FindAsync(id);

            if (rateType == null)
                return NotFound(new { message = "RateType not found!" });

            _context.RateTypes.Remove(rateType);
            await _context.SaveChangesAsync();

            return Ok(new { message = "RateType deleted successfully!" });
        }
    }
}
