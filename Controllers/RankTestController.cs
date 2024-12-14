using BeChinhPhucToan_BE.Data;
using BeChinhPhucToan_BE.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeChinhPhucToan_BE.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BeChinhPhucToan_BE.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RankTestController : ControllerBase
    {
        private readonly DataContext _context;
        public RankTestController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<RankedTest>>> GetAllRankTests()
        {
            var rankTests = await _context.RankedTests.ToListAsync();
            return Ok(rankTests);
        }
        [HttpGet("{question}")]
        public async Task<ActionResult<RankedTest>> getRankTest(string question)
        {
            var questions = await _context.RankedTests.FindAsync(question);
            if (questions is null)
            {
                return NotFound(new { message = "Question not found" });
            }
            return Ok(question);
        }
        [HttpPost]
        public async Task<ActionResult<RankedTest>> addRankTest([FromBody] RankedTest rankedTest)
        {
            if (rankedTest == null)
            {
                return BadRequest(new { message = "RankTest data is requires" });
            }
            try
            {
                _context.RankedTests.Add(rankedTest);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(getRankTest), new { question = rankedTest.question }, rankedTest);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred while adding the student ", detail = ex.Message });
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<RankedTest>> UpdateRankedTest(int id, [FromBody] RankedTest updateRankedTest)
        {
            if (updateRankedTest == null || id != updateRankedTest.id)
            {
                return BadRequest(new { message = "Invalid Ranked Test data or ID mismatch" });
            }
            try
            {
                var existingRankedTest = await _context.RankedTests.FindAsync(id);
                if (existingRankedTest == null)
                {
                    return NotFound(new { message = "Ranked Test not found" });
                }
                existingRankedTest.grade = updateRankedTest.grade;
                existingRankedTest.question = updateRankedTest.question;
                existingRankedTest.answer = updateRankedTest.answer;
                existingRankedTest.rateTypeID = updateRankedTest.rateTypeID;
                _context.RankedTests.Update(existingRankedTest);
                await _context.SaveChangesAsync();
                return Ok(existingRankedTest);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred while updating the ranked test", detail = ex.Message });
            }

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRankedTest(int id)
        {
            try
            {
                var rankedTest = await _context.RankedTests.FindAsync(id);
                if (rankedTest == null)
                {
                    return NotFound(new { message = "Ranked Test not found" });
                }
                _context.RankedTests.Remove(rankedTest);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Ranked Test deleted successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred while deleting the ranked test", detail = ex.Message });
            }
        }
    }
}
