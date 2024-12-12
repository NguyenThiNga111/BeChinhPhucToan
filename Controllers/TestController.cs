using BeChinhPhucToan_BE.Data;
using BeChinhPhucToan_BE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeChinhPhucToan_BE.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class TestController : ControllerBase
	{
		private readonly DataContext _context;

		public TestController(DataContext context)
		{
			_context = context;
		}

		// GET: /Test/{grade}
		[HttpGet("{grade}")]
		public async Task<ActionResult<List<Test>>> getQuestionsByGrade(int grade)
		{
			var questions = await _context.Tests
				.Where(t => t.grade == grade)
				.ToListAsync();

			if (questions.Count == 0)
				return NotFound(new { message = "No questions found for the given grade!" });

			return Ok(questions);
		}

		// POST: /Test/Submit
		[HttpPost("Submit")]
		public async Task<ActionResult> submitAnswers([FromBody] SubmitTestRequest request)
		{
			try
			{
				// Lấy danh sách câu hỏi theo ID từ cơ sở dữ liệu
				var testQuestions = await _context.Tests
					.Where(t => request.Answers.Select(a => a.QuestionId).Contains(t.id))
					.ToListAsync();

				if (testQuestions.Count == 0)
					return NotFound(new { message = "No questions found for the given IDs!" });

				// Tính điểm
				int score = 0;
				foreach (var answer in request.Answers)
				{
					var question = testQuestions.FirstOrDefault(q => q.id == answer.QuestionId);
					if (question != null && question.answer == answer.Answer)
					{
						score++;
					}
				}

				return Ok(new
				{
					message = "Test submitted successfully!",
					score,
					totalQuestions = testQuestions.Count
				});
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An unexpected error occurred: " + ex.Message });
			}
		}
	}

	// Model cho yêu cầu nộp bài
	public class SubmitTestRequest
	{
		public List<UserAnswer> Answers { get; set; } = new List<UserAnswer>(); // Khởi tạo danh sách trống
	}

	public class UserAnswer
	{
		public int QuestionId { get; set; }  // ID của câu hỏi
		public string Answer { get; set; } = string.Empty; // Đáp án của người dùng với giá trị mặc định
	}
}