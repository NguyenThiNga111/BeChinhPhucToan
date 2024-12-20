using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeChinhPhucToan_BE.Models;
using BeChinhPhucToan_BE.Data;

namespace BeChinhPhucToan_BE.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RankedScoreController : ControllerBase
    {
        private readonly DataContext _context;

        public RankedScoreController(DataContext context)
        {
            _context = context;
        }

        // GET: /RankedScore
        [HttpGet]
        public async Task<ActionResult<List<RankedScore>>> GetAllRankedScores()
        {
            var rankedScores = await _context.RankedScores
                .Include(rs => rs.Student) // Bao gồm thông tin Student
                .Include(rs => rs.RateType) // Bao gồm thông tin RateType
                .ToListAsync();
            return Ok(rankedScores);
        }

        // GET: /RankedScore/{rateTypeID}/{studentID}
        [HttpGet("{rateTypeID}/{studentID}")]
        public async Task<ActionResult<RankedScore>> GetRankedScore(int rateTypeID, int studentID)
        {
            var rankedScore = await _context.RankedScores
                .Include(rs => rs.Student)
                .Include(rs => rs.RateType)
                .FirstOrDefaultAsync(rs => rs.rateTypeID == rateTypeID && rs.studentID == studentID);

            if (rankedScore == null)
                return NotFound(new { message = "RankedScore not found!" });

            return Ok(rankedScore);
        }

        // POST: /RankedScore
        [HttpPost]
        public async Task<ActionResult> CreateRankedScore([FromBody] RankedScore rankedScore)
        {
            // Kiểm tra khóa ngoại
            var studentExists = await _context.Students.AnyAsync(s => s.id == rankedScore.studentID);
            var rateTypeExists = await _context.RateTypes.AnyAsync(rt => rt.id == rankedScore.rateTypeID);

            if (!studentExists || !rateTypeExists)
                return BadRequest(new { message = "Student or RateType does not exist!" });

            // Kiểm tra trùng lặp khóa chính
            var existingRankedScore = await _context.RankedScores
                .FirstOrDefaultAsync(rs => rs.rateTypeID == rankedScore.rateTypeID && rs.studentID == rankedScore.studentID);

            if (existingRankedScore != null)
                return Conflict(new { message = "RankedScore already exists!" });

            // Thêm mới RankedScore
            _context.RankedScores.Add(rankedScore);
            await _context.SaveChangesAsync();

            return Ok(new { message = "RankedScore created successfully!" });
        }

        // PUT: /RankedScore/{rateTypeID}/{studentID}
        [HttpPut("{rateTypeID}/{studentID}")]
        public async Task<ActionResult> UpdateRankedScore(int rateTypeID, int studentID, [FromBody] RankedScore updatedRankedScore)
        {
            var rankedScore = await _context.RankedScores
                .FirstOrDefaultAsync(rs => rs.rateTypeID == rateTypeID && rs.studentID == studentID);

            if (rankedScore == null)
                return NotFound(new { message = "RankedScore not found!" });

            // Cập nhật điểm số
            rankedScore.score = updatedRankedScore.score;

            _context.RankedScores.Update(rankedScore);
            await _context.SaveChangesAsync();

            return Ok(new { message = "RankedScore updated successfully!" });
        }

        // DELETE: /RankedScore/{rateTypeID}/{studentID}
        [HttpDelete("{rateTypeID}/{studentID}")]
        public async Task<ActionResult> DeleteRankedScore(int rateTypeID, int studentID)
        {
            var rankedScore = await _context.RankedScores
                .FirstOrDefaultAsync(rs => rs.rateTypeID == rateTypeID && rs.studentID == studentID);

            if (rankedScore == null)
                return NotFound(new { message = "RankedScore not found!" });

            _context.RankedScores.Remove(rankedScore);
            await _context.SaveChangesAsync();

            return Ok(new { message = "RankedScore deleted successfully!" });
        }
    }
}
