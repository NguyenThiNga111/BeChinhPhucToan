using BeChinhPhucToan_BE.Data;
using BeChinhPhucToan_BE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeChinhPhucToan_BE.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> getAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("{phoneNumber}")]
        public async Task<ActionResult<User>> getUser(string phoneNumber)
        {
            var user = await _context.Users.FindAsync(phoneNumber);
            if (user is null)
                return NotFound(new { message = "User is not found!" });
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> addAdmin([FromBody] User user)
        {
            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Created successfully!" });
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException != null && ex.InnerException.Message.Contains("PRIMARY KEY"))
                    return BadRequest(new { message = "The phone number is already in use!" });
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.InnerException.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An unexpected error occurred." });
            }
        }

        [HttpPut("{phoneNumber}")]
        public async Task<ActionResult<User>> updateAdmin([FromBody] User newInfo)
        {
            try
            {
                var user = await _context.Users.FindAsync(newInfo.phoneNumber);
                if (user is null)
                    return NotFound(new { message = "User is not found!" });

                user.password = newInfo.password;

                await _context.SaveChangesAsync();

                return Ok(new { message = "Updated successfully!" });
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException != null && ex.InnerException.Message.Contains("PRIMARY KEY"))
                    return BadRequest(new { message = "The phone number is already in use!" });
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.InnerException.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An unexpected error occurred." });
            }
        }

        [HttpDelete("{phoneNumber}")]
        public async Task<IActionResult> deleteAdmin(string phoneNumber)
        {
            var user = await _context.Users.FindAsync(phoneNumber);

            if (user is null)
                return NotFound(new { message = "User is not found!" });

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Deleted successfully!" });
        }
    }
}
