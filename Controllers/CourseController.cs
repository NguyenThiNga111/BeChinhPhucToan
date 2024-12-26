using BeChinhPhucToan_BE.Data;
using BeChinhPhucToan_BE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeChinhPhucToan_BE.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly DataContext _context;

        public CourseController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Course>>> getAllCourses()
        {
            var courses = await _context.Courses.ToListAsync();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> getCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course is null)
                return NotFound(new { message = "Course is not found!" });
            return Ok(course);
        }

        [HttpPost]
        public async Task<ActionResult<Course>> addCourse([FromBody] Course course)
        {
            try
            {
                _context.Courses.Add(course);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Created successfully!" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An unexpected error occurred." });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Course>> updateCourse([FromBody] Course newInfo)
        {
            try
            {
                var course = await _context.Courses.FindAsync(newInfo.id);
                if (course is null)
                    return NotFound(new { message = "Course is not found!" });

                course.name = newInfo.name;
                course.image = newInfo.image;
                course.grade = newInfo.grade;
                course.status = newInfo.status;

                await _context.SaveChangesAsync();

                return Ok(new { message = "Updated successfully!" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An unexpected error occurred." });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);

            if (course is null)
                return NotFound(new { message = "Course is not found!" });

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Deleted successfully!" });
        }
    }
}
