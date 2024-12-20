using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeChinhPhucToan_BE.Models;
using BeChinhPhucToan_BE.Data;

namespace BeChinhPhucToan_BE.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentNotificationController : ControllerBase
    {
        private readonly DataContext _context;

        public StudentNotificationController(DataContext context)
        {
            _context = context;
        }

        // GET: /StudentNotification
        [HttpGet]
        public async Task<ActionResult<List<StudentNotification>>> GetAllStudentNotifications()
        {
            var notifications = await _context.StudentNotifications.ToListAsync();
            return Ok(notifications);
        }

        // GET: /StudentNotification/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentNotification>> GetStudentNotificationById(int id)
        {
            var notification = await _context.StudentNotifications.FindAsync(id);

            if (notification == null)
                return NotFound(new { message = "StudentNotification not found!" });

            return Ok(notification);
        }

        // POST: /StudentNotification
        [HttpPost]
        public async Task<ActionResult> CreateStudentNotification([FromBody] StudentNotification notification)
        {
            // Validate input
            if (notification == null || string.IsNullOrEmpty(notification.message))
                return BadRequest(new { message = "Invalid input data!" });

            _context.StudentNotifications.Add(notification);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStudentNotificationById), new { id = notification.id }, notification);
        }

        // PUT: /StudentNotification/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateStudentNotification(int id, [FromBody] StudentNotification updatedNotification)
        {
            var existingNotification = await _context.StudentNotifications.FindAsync(id);

            if (existingNotification == null)
                return NotFound(new { message = "StudentNotification not found!" });

            // Update fields
            existingNotification.message = updatedNotification.message;
            existingNotification.isRead = updatedNotification.isRead;

            _context.StudentNotifications.Update(existingNotification);
            await _context.SaveChangesAsync();

            return Ok(new { message = "StudentNotification updated successfully!" });
        }

        // DELETE: /StudentNotification/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudentNotification(int id)
        {
            var notification = await _context.StudentNotifications.FindAsync(id);

            if (notification == null)
                return NotFound(new { message = "StudentNotification not found!" });

            _context.StudentNotifications.Remove(notification);
            await _context.SaveChangesAsync();

            return Ok(new { message = "StudentNotification deleted successfully!" });
        }
    }
}
