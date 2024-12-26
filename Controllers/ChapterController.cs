using BeChinhPhucToan_BE.Data;
using BeChinhPhucToan_BE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeChinhPhucToan_BE.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ChapterController : ControllerBase
    {
        private readonly DataContext _context;

        public ChapterController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Chapter>>> getAllChapters()
        {
            var chapters = await _context.Chapters.ToListAsync();
            return Ok(chapters);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Chapter>> getChapter(int id)
        {
            var chapter = await _context.Chapters.FindAsync(id);
            if (chapter is null)
                return NotFound(new { message = "Chapter is not found!" });
            return Ok(chapter);
        }

        [HttpPost]
        public async Task<ActionResult<Chapter>> addChapter([FromBody] Chapter chapter)
        {
            try
            {
                _context.Chapters.Add(chapter);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Created successfully!" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An unexpected error occurred." });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Chapter>> updateChapter([FromBody] Chapter newInfo)
        {
            try
            {
                var chapter = await _context.Chapters.FindAsync(newInfo.id);
                if (chapter is null)
                    return NotFound(new { message = "Chapter is not found!" });

                chapter.name = newInfo.name;
                chapter.courseID = newInfo.courseID;

                await _context.SaveChangesAsync();

                return Ok(new { message = "Updated successfully!" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An unexpected error occurred." });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteChapter(int id)
        {
            var chapter = await _context.Chapters.FindAsync(id);

            if (chapter is null)
                return NotFound(new { message = "Chapter is not found!" });

            _context.Chapters.Remove(chapter);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Deleted successfully!" });
        }
    }
}
