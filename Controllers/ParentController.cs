using BeChinhPhucToan_BE.Data;
using BeChinhPhucToan_BE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeChinhPhucToan_BE.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ParentController : ControllerBase
    {
        //private readonly DataContext _context;

        //public ParentController(DataContext context)
        //{
        //    _context = context;
        //}

        //// GET: /Parent
        //[HttpGet]
        //public async Task<ActionResult<List<Parent>>> GetAllParents()
        //{
        //    var parents = await _context.Parents.Include(p => p.User) // Bao gồm thông tin User
        //    .ToListAsync();

        //    return Ok(parents);

        //}

        //// GET: /Parent/{phoneNumber}
        //[HttpGet("{phoneNumber}")]
        //public async Task<ActionResult<Parent>> GetParent(string phoneNumber)
        //{
        //    var parent = await _context.Parents
        //        .Include(p => p.User)
        //        .FirstOrDefaultAsync(p => p.phoneNumber == phoneNumber);

        //    if (parent == null)
        //        return NotFound(new { message = "Parent not found!" });

        //    return Ok(parent);
        //}

        //// POST: /Parent
        //[HttpPost]
        //public async Task<ActionResult> AddParent([FromBody] Parent parent)
        //{
        //    if (parent == null || string.IsNullOrEmpty(parent.phoneNumber) || string.IsNullOrEmpty(parent.phoneNumber))
        //        return BadRequest(new { message = "Invalid input data." });

        //    using var transaction = await _context.Database.BeginTransactionAsync();
        //    try
        //    {
        //        // Kiểm tra phoneNumber đã tồn tại
        //        var existingParent = await _context.Parents.FirstOrDefaultAsync(p => p.phoneNumber == parent.phoneNumber);
        //        if (existingParent != null)
        //            return BadRequest(new { message = "Parent with this phoneNumber already exists!" });

        //        // Kiểm tra phoneNumber trong User
        //        var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.phoneNumber == parent.phoneNumber);
        //        if (existingUser == null)
        //        {
        //            // Tạo User mới nếu chưa tồn tại
        //            var newUser = new User
        //            {
        //                phoneNumber = parent.phoneNumber,
        //                password = "default_password", // Mật khẩu mặc định
        //                createdAt = DateTime.Now,
        //                updatedAt = DateTime.Now
        //            };
        //            _context.Users.Add(newUser);
        //            await _context.SaveChangesAsync();
        //        }

        //        // Gán thời gian tạo và cập nhật
        //        parent.createdAt = DateTime.Now;
        //        parent.updatedAt = DateTime.Now;

        //        // Thêm Parent mới
        //        _context.Parents.Add(parent);
        //        await _context.SaveChangesAsync();
        //        await transaction.CommitAsync();

        //        return Ok(new { message = "Parent created successfully!" });
        //    }
        //    catch (Exception ex)
        //    {
        //        await transaction.RollbackAsync();
        //        return StatusCode(500, new { message = $"An error occurred: {ex.Message}" });
        //    }
        //}

        //// PUT: /Parent/{phoneNumber}
        //[HttpPut("{phoneNumber}")]
        //public async Task<ActionResult> UpdateParent(string phoneNumber, [FromBody] Parent updatedParent)
        //{
        //    var parent = await _context.Parents.FirstOrDefaultAsync(p => p.phoneNumber == phoneNumber);
        //    if (parent == null)
        //        return NotFound(new { message = "Parent not found!" });

        //    // Cập nhật thông tin Parent
        //    parent.fullName = updatedParent.fullName ?? parent.fullName;
        //    parent.guardian = updatedParent.guardian ?? parent.guardian;
        //    parent.updatedAt = DateTime.Now;

        //    await _context.SaveChangesAsync();
        //    return Ok(new { message = "Parent updated successfully!" });
        //}

        //// DELETE: /Parent/{phoneNumber}
        //[HttpDelete("{phoneNumber}")]
        //public async Task<ActionResult> DeleteParent(string phoneNumber)
        //{
        //    var parent = await _context.Parents.FirstOrDefaultAsync(p => p.phoneNumber == phoneNumber);
        //    if (parent == null)
        //        return NotFound(new { message = "Parent not found!" });

        //    _context.Parents.Remove(parent);
        //    await _context.SaveChangesAsync();
        //    return Ok(new { message = "Parent deleted successfully!" });
        //}
    }
}
