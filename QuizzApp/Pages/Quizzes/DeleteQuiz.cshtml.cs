using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuizzApp.Data;
using QuizzApp.Model;

namespace QuizzApp.Pages.Quizzes
{
	public class DeleteQuizModel : PageModel
    {
		private readonly ApplicationDbContext _db;

		public DeleteQuizModel(ApplicationDbContext db)
		{
			_db = db;
		}

		public async Task<IActionResult> OnGetAsync(int quizId)
		{
			var userQuiz = await _db.Quiz.Include(q => q.Questions).ThenInclude(q => q.Answers).SingleOrDefaultAsync(q => q.Id == quizId);
			_db.Quiz.Remove(userQuiz);
			await _db.SaveChangesAsync();

			return RedirectToPage("/Quizzes/UserQuizzes");
		}
	}
}
