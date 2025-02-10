﻿using BeChinhPhucToan_BE.Data;
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

        // Get all student
        [HttpGet]
        public async Task<ActionResult<List<Student>>> getAllStudent()
        {
            var students = await _context.Students.ToListAsync();
            return Ok(students);
        }


        //// Get student by parent email
        [HttpGet("{userId}")]
        public async Task<ActionResult<Student>> getStudent(string userId)
        {
            var student = await _context.Students
                .Where(s => s.userId == userId)
                .ToListAsync();
            return Ok(student);
        }

        //// Post add student 
        [HttpPost]
        public async Task<ActionResult<Student>> addUser([FromBody] Student student)
        {
            var newStudent = await _context.Students.FindAsync(student.fullName);
            if (newStudent is null)
            {
                _context.Students.Add(student);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Tạo mới thành công!" });
            }

            return BadRequest(new { message = "Tên của bé đã được đăng ký!" });
        }
        //[HttpPost]
        //public async Task<ActionResult<Student>> addStudent([FromBody] Student student)
        //{
        //    if(student == null)
        //    {
        //        return BadRequest(new { message = "Student data is required" });
        //    }
        //    try
        //    {
        //        _context.Students.Add(student);
        //        await _context.SaveChangesAsync();
        //        return CreatedAtAction(nameof(getStudent), new { parentPhone = student.parentPhone }, student);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred while adding the student ", detail = ex.Message});
        //    }

        //}
        //// Put update data for id
        //[HttpPut("{id}")]
        //public async Task<ActionResult<Student>> updateStudent(int id, [FromBody] Student updateStudent)
        //{
        //    if(updateStudent == null || id != updateStudent.id)
        //    {
        //        return BadRequest(new { message = "Invalid student data or ID mismatch" });
        //    }
        //    try 
        //    {
        //        var existingStudent = await _context.Students.FindAsync(id);
        //        if(existingStudent == null)
        //        {
        //            return NotFound(new { message = "Student not found" });
        //        }
        //        existingStudent.fullName = updateStudent.fullName;
        //        existingStudent.image = updateStudent.image;
        //        existingStudent.dateOfBirth = updateStudent.dateOfBirth;
        //        existingStudent.grade = updateStudent.grade;
        //        existingStudent.parentPhone = updateStudent.parentPhone;
        //        _context.Students.Update(existingStudent);
        //        await _context.SaveChangesAsync();
        //        return Ok(existingStudent);
        //    }
        //    catch (Exception ex) 
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, new {message = "An error occurred while updating the student", detail = ex.Message });
        //    }
        //}
        //// Delete student for id
        //[HttpDelete("{id}")]
        //public async Task<ActionResult> deleteStudent(int id)
        //{
        //    try
        //    {
        //        var student = await _context.Students.FindAsync(id);
        //        if(student == null)
        //        {
        //            return NotFound(new { message = "Student not found" });
        //        }
        //        _context.Students.Remove(student);
        //        await _context.SaveChangesAsync();
        //        return Ok(new { message = "Student delete successfull" });
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred while deleting the student", detail = ex.Message });
        //    }
        //}
        //// Filter student for grade
        //[HttpGet("filterbygrade/{grade}")]
        //public async Task<ActionResult<List<Student>>> getStudentByGrade(int grade)
        //{
        //    try
        //    {
        //        var students = await _context.Students.Where(s => s.grade == grade).ToListAsync();
        //        if(students == null || students.Count == 0)
        //        {
        //            return NotFound(new { message = "NO student found for the given grade." });
        //        }
        //        return Ok(students);
        //    }catch(Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, new
        //        {
        //            message = "An error occourred while fetching the students.",
        //            detail = ex.Message
        //        });
        //    }
        //}
    }
}
