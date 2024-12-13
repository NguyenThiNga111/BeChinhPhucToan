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
    public class StudentController : ControllerBase
    {
        private readonly DataContext _context;
        public StudentController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Student>>> getAllStudent()
        {
            var students = await _context.Students.ToListAsync();
            return Ok(students);
        }
        [HttpGet("{parentEmail}")]
        public async Task<ActionResult<Student>> getStudent(string parentEmail)
        {
            var student = await _context.Students.FindAsync(parentEmail);
            if(student is null)
            {
                return NotFound(new { message = "Student not found" });
            }
            return Ok(student);
        }
        [HttpPost]
        public async Task<ActionResult<Student>> addStudent([FromBody] Student student)
        {
            if(student == null)
            {
                return BadRequest(new { message = "Student data is required" });
            }
            try
            {
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(getStudent), new { parentEmail = student.parentEmail }, student);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred while adding the student ", detail = ex.Message});
            }

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> updateStudent(int id, [FromBody] Student updateStudent)
        {
            if(updateStudent == null || id != updateStudent.id)
            {
                return BadRequest(new { message = "Invalid student data or ID mismatch" });
            }
            try 
            {
                var existingStudent = await _context.Students.FindAsync(id);
                if(existingStudent == null)
                {
                    return NotFound(new { message = "Student not found" });
                }
                existingStudent.fullName = updateStudent.fullName;
                existingStudent.image = updateStudent.image;
                existingStudent.dateOfBirth = updateStudent.dateOfBirth;
                existingStudent.grade = updateStudent.grade;
                existingStudent.parentEmail = updateStudent.parentEmail;
                _context.Students.Update(existingStudent);
                await _context.SaveChangesAsync();
                return Ok(existingStudent);
            }
            catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new {message = "An error occurred while updating the student", detail = ex.Message });
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> deleteStudent(int id)
        {
            try
            {
                var student = await _context.Students.FindAsync(id);
                if(student == null)
                {
                    return NotFound(new { message = "Student not found" });
                }
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Student delete successfull" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred while deleting the student", detail = ex.Message });
            }
        }
    }
}
