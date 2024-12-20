using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeChinhPhucToan_BE.Models;
using BeChinhPhucToan_BE.Data;

namespace BeChinhPhucToan_BE.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NotifyStudentController : ControllerBase
    {
        private readonly DataContext _context;

        public NotifyStudentController(DataContext context)
        {
            _context = context;
        }

        // GET: /NotifyStudent
        [HttpGet]
        public async Task<ActionResult<List<NotifyStudent>>> GetAllNotifyStudents()
        {
            var notifyStudents = await _context.NotifyStudents
                .Include(ns => ns.Student) // Bao gồm thông tin Student
                .Include(ns => ns.StudentNotification) // Bao gồm thông tin StudentNotification
                .ToListAsync();

            return Ok(notifyStudents);
        }

        // POST: /NotifyStudent
        [HttpPost]
        public async Task<ActionResult> AddNotifyStudent([FromBody] NotifyStudent notifyStudent)
        {
            // Kiểm tra khóa ngoại
            var studentExists = await _context.Students.AnyAsync(s => s.id == notifyStudent.studentID);
            var notificationExists = await _context.StudentNotifications.AnyAsync(n => n.id == notifyStudent.notificationID);

            if (!studentExists || !notificationExists)
                return BadRequest(new { message = "Student or Notification does not exist!" });

            // Kiểm tra trùng lặp khóa chính
            var existingNotifyStudent = await _context.NotifyStudents
                .FirstOrDefaultAsync(ns => ns.notificationID == notifyStudent.notificationID
                                         && ns.studentID == notifyStudent.studentID);
            if (existingNotifyStudent != null)
                return Conflict(new { message = "NotifyStudent already exists!" });

            // Thêm bản ghi mới nếu không trùng lặp
            _context.NotifyStudents.Add(notifyStudent);
            await _context.SaveChangesAsync();

            return Ok(new { message = "NotifyStudent created successfully!" });
        }

        // DELETE: /NotifyStudent/{notificationID}/{studentID}
        [HttpDelete("{notificationID}/{studentID}")]
        public async Task<IActionResult> DeleteNotifyStudent(int notificationID, int studentID)
        {
            var notifyStudent = await _context.NotifyStudents
                .FirstOrDefaultAsync(ns => ns.notificationID == notificationID && ns.studentID == studentID);

            if (notifyStudent == null)
                return NotFound(new { message = "NotifyStudent not found!" });

            _context.NotifyStudents.Remove(notifyStudent);
            await _context.SaveChangesAsync();

            return Ok(new { message = "NotifyStudent deleted successfully!" });
        }
    }
}
