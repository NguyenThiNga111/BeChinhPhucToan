using BeChinhPhucToan_BE.Data;
using BeChinhPhucToan_BE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeChinhPhucToan_BE.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class TestManageController : ControllerBase
	{
		private readonly DataContext _context;

		public TestManageController(DataContext context)
		{
			_context = context;
		}

		// GET: /Test
		// Lấy danh sách tất cả bài test
		[HttpGet]
		public async Task<ActionResult<List<Test>>> getAllTests()
		{
			var tests = await _context.Tests.ToListAsync();
			return Ok(tests);
		}

		// GET: /Test/{id}
		// Lấy thông tin một bài test theo ID
		[HttpGet("{id}")]
		public async Task<ActionResult<Test>> getTestById(int id)
		{
			var test = await _context.Tests.FindAsync(id);
			if (test == null)
			{
				return NotFound(new { message = "Test not found!" });
			}
			return Ok(test);
		}

		// POST: /Test
		// Thêm mới một bài test
		[HttpPost]
		public async Task<ActionResult> addTest([FromBody] Test test)
		{
			try
			{
				_context.Tests.Add(test);
				await _context.SaveChangesAsync();
				return Ok(new { message = "Test added successfully!", test });
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = "An error occurred", error = ex.Message });
			}
		}

		// PUT: /Test/{id}
		// Cập nhật thông tin một bài test
		[HttpPut("{id}")]
		public async Task<ActionResult> updateTest(int id, [FromBody] Test updatedTest)
		{
			try
			{
				var existingTest = await _context.Tests.FindAsync(id);
				if (existingTest == null)
				{
					return NotFound(new { message = "Test not found!" });
				}

				// Cập nhật thông tin
				existingTest.grade = updatedTest.grade;
				existingTest.question = updatedTest.question;
				existingTest.answer = updatedTest.answer;

				await _context.SaveChangesAsync();
				return Ok(new { message = "Test updated successfully!", updatedTest });
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = "An error occurred", error = ex.Message });
			}
		}

		// DELETE: /Test/{id}
		// Xóa một bài test
		[HttpDelete("{id}")]
		public async Task<ActionResult> deleteTest(int id)
		{
			try
			{
				var test = await _context.Tests.FindAsync(id);
				if (test == null)
				{
					return NotFound(new { message = "Test not found!" });
				}

				_context.Tests.Remove(test);
				await _context.SaveChangesAsync();
				return Ok(new { message = "Test deleted successfully!" });
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = "An error occurred", error = ex.Message });
			}
		}
	}
}
