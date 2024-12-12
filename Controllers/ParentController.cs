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
		private readonly DataContext _context;

		public ParentController(DataContext context)
		{
			_context = context;
		}

		// GET: /Parent
		[HttpGet]
		public async Task<ActionResult<List<Parent>>> getAllParents()
		{
			var parents = await _context.Parents
				.Include(p => p.User) // Bao gồm thông tin User liên kết
				.ToListAsync();
			return Ok(parents);
		}

		// GET: /Parent/{email}
		[HttpGet("{email}")]
		public async Task<ActionResult<Parent>> getParent(string email)
		{
			var parent = await _context.Parents
				.Include(p => p.User)
				.FirstOrDefaultAsync(p => p.email == email);

			if (parent is null)
				return NotFound(new { message = "Parent is not found!" });

			return Ok(parent);
		}

		// POST: /Parent
		[HttpPost]
		public async Task<ActionResult> addParent([FromBody] Parent parent)
		{
			try
			{
				// Kiểm tra nếu số điện thoại đã tồn tại trong bảng User
				var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.phoneNumber == parent.phoneNumber);
				if (existingUser == null)
				{
					// Tạo User mới nếu chưa tồn tại
					var newUser = new User
					{
						phoneNumber = parent.phoneNumber,
						password = parent.User.password, // Cần mã hóa mật khẩu
						isVerify = false
					};
					_context.Users.Add(newUser);
				}

				// Thêm Parent vào cơ sở dữ liệu
				_context.Parents.Add(parent);
				await _context.SaveChangesAsync();

				return Ok(new { message = "Parent created successfully!" });
			}
			catch (DbUpdateException ex)
			{
				if (ex.InnerException != null && ex.InnerException.Message.Contains("PRIMARY KEY"))
					return BadRequest(new { message = "The email is already in use!" });
				return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.InnerException.Message });
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An unexpected error occurred." });
			}
		}

		// PUT: /Parent/{email}
		[HttpPut("{email}")]
		public async Task<ActionResult> updateParent(string email, [FromBody] Parent updatedParent)
		{
			try
			{
				// Tìm Parent theo email
				var parent = await _context.Parents.FirstOrDefaultAsync(p => p.email == email);
				if (parent is null)
					return NotFound(new { message = "Parent is not found!" });

				// Cập nhật thông tin Parent
				parent.fullName = updatedParent.fullName;
				parent.guardian = updatedParent.guardian;

				// Nếu cần cập nhật User (ví dụ: mật khẩu)
				var user = await _context.Users.FirstOrDefaultAsync(u => u.phoneNumber == updatedParent.phoneNumber);
				if (user != null && updatedParent.User != null)
				{
					user.password = updatedParent.User.password; // Cần mã hóa mật khẩu
				}

				await _context.SaveChangesAsync();
				return Ok(new { message = "Parent updated successfully!" });
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An unexpected error occurred." });
			}
		}

		// DELETE: /Parent/{email}
		[HttpDelete("{email}")]
		public async Task<IActionResult> deleteParent(string email)
		{
			try
			{
				// Tìm Parent theo email
				var parent = await _context.Parents.FirstOrDefaultAsync(p => p.email == email);
				if (parent is null)
					return NotFound(new { message = "Parent is not found!" });

				// Xóa Parent
				_context.Parents.Remove(parent);
				await _context.SaveChangesAsync();

				return Ok(new { message = "Parent deleted successfully!" });
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An unexpected error occurred." });
			}
		}
	}
}
